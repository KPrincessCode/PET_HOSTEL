using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PET_HOSTEL
{
    public partial class UserPanel : Form
    {
        private SqlConnection connect;
        private bool isTotalChecked = false;

        private string currentUsername;
        private string loggedInUsername;

        public UserPanel(string username)
        {
            InitializeComponent();
            DataAccess dataAccess = new DataAccess();
            connect = new SqlConnection(dataAccess.GetConnectionString());
            currentUsername = username;
            loggedInUsername = username;
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
            username.Text = loggedInUsername;
        }

        private int GetPetCostFromDatabase(string petType)
        {
            int cost = 0;

            try
            {
                connect.Open();
                string query = $"SELECT {petType.ToLower()}_cost FROM cost";
                SqlCommand cmd = new SqlCommand(query, connect);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    cost = Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show($"No cost found for {petType}. Using default value.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching pet cost: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }

            return cost;
        }

        private int ExtractBookingIdFromJson(string json)
        {
            Match match = Regex.Match(json, "\"id\"\\s*:\\s*(\\d+)");
            if (match.Success)
            {
                return Convert.ToInt32(match.Groups[1].Value);
            }

            return 0;
        }

        private int ComputeTotalAmount()
        {
            int totalAmount = GetPetCostFromDatabase(petType.SelectedItem.ToString());

            switch (age.SelectedItem.ToString())
            {
                case "Up to 5 months": totalAmount += 150; break;
                case "Up to 1 year": totalAmount += 250; break;
                case "Up to 3 years": totalAmount += 350; break;
                case "Up to 5 years": totalAmount += 450; break;
                case "More than 5 years": totalAmount += 480; break;
            }

            if (injectionStatus.SelectedItem.ToString() == "No")
            {
                totalAmount += 500;
            }

            if (medicineNeeded.SelectedItem.ToString() == "Yes")
            {
                totalAmount += 300;
            }

            TimeSpan dateDifference = checkoutDate.Value.Date - startDate.Value.Date;
            int days = dateDifference.Days;

            if (days == 0)
            {
                days = 1;
            }

            if (days > 0)
            {
                totalAmount += days * 300;
            }

            return totalAmount;
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrEmpty(username.Text) ||
                petType.SelectedIndex == -1 ||
                age.SelectedIndex == -1 ||
                injectionStatus.SelectedIndex == -1 ||
                medicineNeeded.SelectedIndex == -1)
            {
                MessageBox.Show("All fields must be filled.");
                return false;
            }

            return true;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (!isTotalChecked)
            {
                MessageBox.Show("Please check the total amount first.");
                return;
            }

            if (!IsFormValid())
            {
                return;
            }

            int totalAmount = ComputeTotalAmount();

            try
            {
                connect.Open();

                string query = @"UPDATE admin 
                                 SET pet = @pet,
                                     pet_age = @age,
                                     injection_status = @injectionStatus,
                                     medicine_needed = @medicineNeeded,
                                     start_date = @startDate,
                                     checkout_date = @checkoutDate,
                                     payment_amount = @totalAmount,
                                     payment_status = @paymentStatus
                                 WHERE username = @username";

                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@pet", petType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@age", age.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@injectionStatus", injectionStatus.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@medicineNeeded", medicineNeeded.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@startDate", startDate.Value);
                cmd.Parameters.AddWithValue("@checkoutDate", checkoutDate.Value);
                cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@paymentStatus", "unpaid");
                cmd.Parameters.AddWithValue("@username", username.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    int apiBookingId = 0;

                    using (HttpClient client = new HttpClient())
                    {
                        var data = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("pet_id", "2"),
                            new KeyValuePair<string, string>("owner_name", username.Text),
                            new KeyValuePair<string, string>("pet_type", petType.SelectedItem.ToString()),
                            new KeyValuePair<string, string>("service_type", "Boarding"),
                            new KeyValuePair<string, string>("medicine_needed", medicineNeeded.SelectedItem.ToString()),
                            new KeyValuePair<string, string>("injection_status", injectionStatus.SelectedItem.ToString()),
                            new KeyValuePair<string, string>("check_in_date", startDate.Value.ToString("yyyy-MM-dd")),
                            new KeyValuePair<string, string>("check_out_date", checkoutDate.Value.ToString("yyyy-MM-dd")),
                            new KeyValuePair<string, string>("payment_amount", totalAmount.ToString()),
                            new KeyValuePair<string, string>("payment_status", "unpaid"),
                            new KeyValuePair<string, string>("status", "Pending")
                        });

                        var response = client.PostAsync("http://127.0.0.1:8000/api/bookings", data).Result;
                        string apiResult = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode)
                        {
                            apiBookingId = ExtractBookingIdFromJson(apiResult);

                            if (apiBookingId == 0)
                            {
                                MessageBox.Show("Booking sent to API, but booking ID was not detected.");
                                return;
                            }

                            MessageBox.Show("Booking sent to Laravel API!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to send booking to API.\n" + apiResult);
                            return;
                        }
                    }

                    PaymentMethod paymentForm = new PaymentMethod(loggedInUsername, apiBookingId, totalAmount);
                    paymentForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error saving data or username not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            username.Text = string.Empty;
            petType.SelectedIndex = -1;
            age.SelectedIndex = -1;
            injectionStatus.SelectedIndex = -1;
            medicineNeeded.SelectedIndex = -1;
            startDate.Value = DateTime.Now;
            checkoutDate.Value = DateTime.Now;
            isTotalChecked = false;
        }

        private void button_Logout_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string query = "UPDATE admin SET login_status = 0 WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }

            Login lForm1 = new Login();
            lForm1.Show();
            this.Hide();
        }

        private void btn_CheckTotal_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
            {
                return;
            }

            int loginStatus = 0;

            try
            {
                connect.Open();

                string query = "SELECT login_status FROM admin WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@username", username.Text);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    loginStatus = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            finally
            {
                connect.Close();
            }

            if (loginStatus != 1)
            {
                MessageBox.Show("Please insert your correct username.");
                return;
            }

            int totalAmount = ComputeTotalAmount();

            MessageBox.Show($"Total Amount: {totalAmount} Taka", "Total Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isTotalChecked = true;
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void username_SelectedIndexChanged(object sender, EventArgs e) { }
        private void username_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void startDate_ValueChanged(object sender, EventArgs e) { }
        private void button_TotalAmount_Click(object sender, EventArgs e) { }
        private void label_Check_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
    }
}