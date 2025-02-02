using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PET_HOSTEL
{
    public partial class Changepasss : Form
    {
       
        public string UserEmail { get; set; } 
        private readonly string connectionString;

        public Changepasss()
        {
            InitializeComponent();

            DataAccess dataAccess = new DataAccess();
            connectionString = dataAccess.GetConnectionString();
        }

        private void updt_Click(object sender, EventArgs e)
        {
            if (npass.Text != cpass.Text)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            MessageBox.Show($"Updating password for: {UserEmail}");

            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string query = "UPDATE admin SET password = @Password WHERE email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("@Password", npass.Text); // New password
                        command.Parameters.AddWithValue("@Email", UserEmail); // User's email

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!");
                            
                            Login login = new Login();
                            login.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Error: User not found or password not updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }

        }

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                if (sp.Checked)
                {
                    npass.PasswordChar = '\0';
                    cpass.PasswordChar = '\0';
                }
                else
                {
                    npass.PasswordChar = '*';
                    cpass.PasswordChar = '*';
                }

            }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void npass_TextChanged(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    } }

