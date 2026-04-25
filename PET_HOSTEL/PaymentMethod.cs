using System;
using System.Windows.Forms;

namespace PET_HOSTEL
{
    public partial class PaymentMethod : Form
    {
        private string loggedInUsername;
        private int bookingId;
        private decimal paymentAmount;

        public PaymentMethod(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            bookingId = 0;
            paymentAmount = 0;
        }

        public PaymentMethod(string username, int apiBookingId, decimal totalAmount)
        {
            InitializeComponent();
            loggedInUsername = username;
            bookingId = apiBookingId;
            paymentAmount = totalAmount;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void visa_Click(object sender, EventArgs e)
        {
            CardPayment a = new CardPayment(loggedInUsername, bookingId, paymentAmount);
            a.Show();
        }

        private void masterCard_Click(object sender, EventArgs e)
        {
            CardPayment b = new CardPayment(loggedInUsername, bookingId, paymentAmount);
            b.Show();
        }

        private void payPal_Click(object sender, EventArgs e)
        {
            CardPayment c = new CardPayment(loggedInUsername, bookingId, paymentAmount);
            c.Show();
        }

        private void bkash_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment(loggedInUsername, bookingId, paymentAmount);
            d.Show();
        }

        private void nogod_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment(loggedInUsername, bookingId, paymentAmount);
            d.Show();
        }

        private void rocked_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment(loggedInUsername, bookingId, paymentAmount);
            d.Show();
        }

        private void upay_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment(loggedInUsername, bookingId, paymentAmount);
            d.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CardPayment f = new CardPayment(loggedInUsername, bookingId, paymentAmount);
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