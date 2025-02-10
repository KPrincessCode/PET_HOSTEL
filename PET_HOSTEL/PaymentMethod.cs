using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PET_HOSTEL
{
    public partial class PaymentMethod : Form
    {
        private string loggedInUsername;
        public PaymentMethod(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void visa_Click(object sender, EventArgs e)
        {
            CardPayment a = new CardPayment(loggedInUsername);
            a.Show();         
        }

        private void masterCard_Click(object sender, EventArgs e)
        {
            CardPayment b = new CardPayment(loggedInUsername);
            b.Show();         
        }

        private void payPal_Click(object sender, EventArgs e)
        {
            CardPayment c = new CardPayment(loggedInUsername);
            c.Show();
        }

        private void bkash_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment(loggedInUsername);
            d.Show();
        }

        private void nogod_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment(loggedInUsername);
            d.Show();         
        }

        private void rocked_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment(loggedInUsername);
            d.Show();
        }

        private void upay_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment(loggedInUsername);
            d.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CardPayment f = new CardPayment(loggedInUsername);  
            f.Show();
        }


        private void btn_Back_Click(object sender, EventArgs e)
        {
            UserPanel userpnl = new UserPanel(loggedInUsername);
            userpnl.Show();
            this.Hide();
        }
    }
}
