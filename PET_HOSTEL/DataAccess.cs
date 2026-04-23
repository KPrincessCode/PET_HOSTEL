using System;
using System.Data.SqlClient;
using System.IO;

namespace PET_HOSTEL
{
    public class DataAccess
    {
        private string connectionString;

        public DataAccess()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PetHostel_Database.mdf");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Initial Catalog=PetHostel_Database_Kyle;Integrated Security=True;Connect Timeout=30";
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

        public void ConnectToDatabase()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
            }
        }
    }
}