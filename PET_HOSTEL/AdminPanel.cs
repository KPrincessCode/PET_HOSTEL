using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace PET_HOSTEL
{
    public partial class AdminPanel : Form
    {


        private readonly string connectionString;


        public AdminPanel()
        {
            InitializeComponent();
            DataAccess dataAccess = new DataAccess();
            connectionString = dataAccess.GetConnectionString();
            ShowAdminData();
        }
        private void ShowAdminData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM admin";
                   
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                
                    DataTable table = new DataTable();
                 
                    conn.Open();
                 
                    adapter.Fill(table);
                 
                    if (table.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = table;
                    }
                    else
                    {
                        MessageBox.Show("No data found in the admin table.");
                    }
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }


        private void LoadCostData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM cost";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();

                    conn.Open();

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = table;
                    }
                    else
                    {
                        MessageBox.Show("No data found in the cost table.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }



        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

      

        private void AdminPanel_Load(object sender, EventArgs e)
        {            
            this.costTableAdapter.Fill(this.petHostel_DatabaseDataSet1.cost);          
            this.adminTableAdapter.Fill(this.petHostel_DatabaseDataSet.admin);      
        }


        private void btn_Show_Click_1(object sender, EventArgs e)
        {
        
            string username = txt_UsernameSearch.Text.Trim();

             
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username to search.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    
                    string query = "SELECT * FROM admin WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@username", username);

                       
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                       
                        dataGridView1.DataSource = dataTable;

                       
                        signup_email.Text = "";
                        txt_UsernameSearch.Text = "";
                        signup_password.Text = "";
                        signup_dob.Value = DateTime.Today;
                        txt_usertype.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error retrieving data: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void btn_Refresh_Click_1(object sender, EventArgs e)
        {
            ShowAdminData();
            LoadCostData();
        }

        private void btn_Uptate_Click_1(object sender, EventArgs e)
        {
            if (signup_email.Text == "" || signup_username.Text == "")
            {
                MessageBox.Show("Please enter a valid username and email to update.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string updateQuery = "UPDATE admin SET email = @newEmail, password = @newPassword, dob = @newDob, usertype = @newUsertype WHERE username = @username";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@newEmail", signup_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@newPassword", signup_password.Text.Trim());
                            cmd.Parameters.AddWithValue("@newDob", signup_dob.Value);

                            int newUsertype;
                            if (int.TryParse(txt_usertype.Text.Trim(), out newUsertype))
                            {
                                cmd.Parameters.AddWithValue("@newUsertype", newUsertype);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@newUsertype", 1);
                            }

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User information updated successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                signup_email.Text = "";
                                signup_username.Text = "";
                                signup_password.Text = "";
                                signup_dob.Value = DateTime.Today;
                                txt_usertype.Text = "";

                                ShowAdminData();
                            }
                            else
                            {
                                MessageBox.Show("Update failed. User not found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            if (signup_username.Text == "")
            {
                MessageBox.Show("Please enter a username to delete.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string deleteQuery = "DELETE FROM admin WHERE username = @username";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User deleted successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                signup_email.Text = "";
                                signup_username.Text = "";
                                signup_password.Text = "";
                                signup_dob.Value = DateTime.Today;
                                txt_usertype.Text = "";

                                ShowAdminData();
                            }
                            else
                            {
                                MessageBox.Show("Delete failed. User not found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting data: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void signup_btn_Click_1(object sender, EventArgs e)
        {
            if (signup_email.Text == "" || signup_username.Text == "" || signup_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsValidEmail(signup_email.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string checkUsername = "SELECT * FROM admin WHERE username = @username";

                        using (SqlCommand checkUser = new SqlCommand(checkUsername, conn))
                        {
                            checkUser.Parameters.AddWithValue("@username", signup_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(signup_username.Text + " already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO admin (email, username, password, dob, usertype, date_created) " +
                                    "VALUES(@email, @username, @pass, @dob, @usertype, @date)";

                                DateTime date = DateTime.Today;

                                using (SqlCommand cmd = new SqlCommand(insertData, conn))
                                {
                                    cmd.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                    cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", signup_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dob", signup_dob.Value);
                                    cmd.Parameters.AddWithValue("@date", date);

                                    int userType;
                                    if (int.TryParse(txt_usertype.Text.Trim(), out userType))
                                    {
                                        cmd.Parameters.AddWithValue("@usertype", userType);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@usertype", 1);
                                    }

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    signup_email.Text = "";
                                    signup_username.Text = "";
                                    signup_password.Text = "";
                                    signup_dob.Value = DateTime.Today;
                                    txt_usertype.Text = "";

                                    signup_email.Focus();
                                    ShowAdminData();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
 

        private void signup_showPass_CheckedChanged_1(object sender, EventArgs e)
        {
            if (signup_showPass.Checked)
            {
                signup_password.PasswordChar = '\0';
            }
            else
            {
                signup_password.PasswordChar = '*';
            }
        }


        private void signup_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click_1(object sender, EventArgs e)
        {
            
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
            
        }

        private void comboBox_petType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Cost_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_UpdateCost_Click(object sender, EventArgs e)
        {
            string selectedPetType = comboBox_petType.SelectedItem?.ToString();
            string cost = textBox_Cost.Text.Trim();

            if (string.IsNullOrEmpty(selectedPetType) || string.IsNullOrEmpty(cost))
            {
                MessageBox.Show("Please select a pet type and enter a cost.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "";

                    switch (selectedPetType.ToLower())
                    {
                        case "cat":
                            query = "UPDATE cost SET cat_cost = @cost";
                            break;
                        case "dog":
                            query = "UPDATE cost SET dog_cost = @cost";
                            break;
                        case "rabbit":
                            query = "UPDATE cost SET rabbit_cost = @cost";
                            break;
                        case "tortoise":
                            query = "UPDATE cost SET tortoise_cost = @cost";
                            break;
                        case "hamster":
                            query = "UPDATE cost SET hamster_cost = @cost";
                            break;
                        case "bird":
                            query = "UPDATE cost SET bird_cost = @cost";
                            break;
                        case "fish":
                            query = "UPDATE cost SET fish_cost = @cost";
                            break;
                        default:
                            MessageBox.Show("Invalid pet type selected.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cost", int.Parse(cost));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show($"{selectedPetType} cost updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCostData();
                        }
                        else
                        {
                            MessageBox.Show("Cost update failed. No rows were affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_Updatee_Click(object sender, EventArgs e)
        {

        }
    }
}
