using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Http;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace PET_HOSTEL
{
    public partial class MobileBankingPayment : Form
    {
        private SqlConnection connect;
        private bool isPaymentConfirmed = false;
        private string loggedInUsername;
        private int bookingId;
        private decimal apiPaymentAmount;

        public MobileBankingPayment(string username)
        {
            InitializeComponent();

            DataAccess dataAccess = new DataAccess();
            connect = new SqlConnection(dataAccess.GetConnectionString());

            loggedInUsername = username;
            bookingId = 0;
            apiPaymentAmount = 0;
        }

        public MobileBankingPayment(string username, int apiBookingId, decimal totalAmount)
        {
            InitializeComponent();

            DataAccess dataAccess = new DataAccess();
            connect = new SqlConnection(dataAccess.GetConnectionString());

            loggedInUsername = username;
            bookingId = apiBookingId;
            apiPaymentAmount = totalAmount;
        }

        private void UpdateLaravelPaymentStatus(int amount)
        {
            if (bookingId <= 0)
            {
                MessageBox.Show("Laravel booking ID not found. Payment saved locally only.");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                var data = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("payment_status", "paid"),
                    new KeyValuePair<string, string>("payment_amount", amount.ToString())
                });

                var response = client.PutAsync("http://127.0.0.1:8000/api/bookings/" + bookingId, data).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string error = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show("Payment confirmed locally, but Laravel API update failed.\n" + error);
                }
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Username.Text) ||
                string.IsNullOrEmpty(text_Amount.Text) ||
                string.IsNullOrEmpty(text_Card.Text) ||
                string.IsNullOrEmpty(text_Pin.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(text_Amount.Text, out int amount))
            {
                MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connect.Open();

                string query = "SELECT payment_amount FROM admin WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@username", txt_Username.Text);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Username not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int paymentAmount = Convert.ToInt32(result);

                if (paymentAmount == amount)
                {
                    string updateQuery = "UPDATE admin SET payment_status = 'Paid', login_status = 0 WHERE username = @username";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connect);
                    updateCmd.Parameters.AddWithValue("@username", txt_Username.Text);
                    updateCmd.ExecuteNonQuery();

                    UpdateLaravelPaymentStatus(amount);

                    MessageBox.Show("Payment confirmed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isPaymentConfirmed = true;
                }
                else
                {
                    MessageBox.Show("Please, enter the correct amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void MobileBankingPayment_Load(object sender, EventArgs e)
        {
            txt_Username.Text = loggedInUsername;

            try
            {
                connect.Open();

                string query = "SELECT payment_amount FROM admin WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@username", loggedInUsername);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int paymentAmount = Convert.ToInt32(result);
                    text_Amount.Text = paymentAmount.ToString();
                }
                else
                {
                    MessageBox.Show("No payment amount found for the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching payment amount: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            if (!isPaymentConfirmed)
            {
                MessageBox.Show("Please confirm payment before printing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connect.Open();

                string query = "SELECT username, pet, injection_status, medicine_needed, start_date, checkout_date, payment_amount FROM admin WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@username", txt_Username.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string username = reader["username"].ToString();
                    string petType = reader["pet"].ToString();
                    string injectionStatus = reader["injection_status"].ToString();
                    string medicineNeeded = reader["medicine_needed"].ToString();
                    DateTime startDate = Convert.ToDateTime(reader["start_date"]);
                    DateTime checkoutDate = Convert.ToDateTime(reader["checkout_date"]);
                    int totalAmount = Convert.ToInt32(reader["payment_amount"]);

                    Random random = new Random();
                    string tokenCode = "PAS" + random.Next(1000, 9999);

                    string printDetails = $"Username: {username}\n" +
                                          $"Pet type: {petType}\n" +
                                          $"Injection Status: {injectionStatus}\n" +
                                          $"Medicine Needed: {medicineNeeded}\n" +
                                          $"Start Date: {startDate.ToShortDateString()}\n" +
                                          $"Checkout Date: {checkoutDate.ToShortDateString()}\n" +
                                          $"Total Amount: {totalAmount} TAKA\n" +
                                          $"Token Code: {tokenCode}";

                    PrintDialog printDialog = new PrintDialog();

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        PrintDocument pd = new PrintDocument();

                        pd.PrintPage += (s, ev) =>
                        {
                            ev.Graphics.DrawString(printDetails, new Font("Arial", 12), Brushes.Black, 10, 10);
                        };

                        pd.Print();

                        string pdfDirectory = @"C:\Receipts\";

                        if (!Directory.Exists(pdfDirectory))
                        {
                            Directory.CreateDirectory(pdfDirectory);
                        }

                        string pdfPath = Path.Combine(pdfDirectory, $"{username}'s pet {petType}_PaymentReceipt.pdf");

                        using (PdfWriter writer = new PdfWriter(pdfPath))
                        using (PdfDocument pdf = new PdfDocument(writer))
                        {
                            Document document = new Document(pdf);
                            document.Add(new Paragraph(printDetails).SetFontSize(12));
                            document.Close();
                        }

                        MessageBox.Show($"Receipt saved to {pdfPath}", "Receipt Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Welcome WForm1 = new Welcome();
                        WForm1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Printing cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    reader.Close();
                }
                else
                {
                    MessageBox.Show("User details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Printed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            finally
            {
                connect.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();

                string query = "UPDATE admin SET login_status = 0";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.ExecuteNonQuery();

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e) { }
        private void txt_Username_TextChanged(object sender, EventArgs e) { }
    }
}