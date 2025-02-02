
namespace PET_HOSTEL
{
    partial class MobileBankingPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_Pin = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.text_Amount = new System.Windows.Forms.TextBox();
            this.text_Card = new System.Windows.Forms.TextBox();
            this.button_Print = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.BackColor = System.Drawing.Color.Red;
            this.btn_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Confirm.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirm.ForeColor = System.Drawing.Color.White;
            this.btn_Confirm.Location = new System.Drawing.Point(126, 354);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(312, 36);
            this.btn_Confirm.TabIndex = 25;
            this.btn_Confirm.Text = "Confirm";
            this.btn_Confirm.UseVisualStyleBackColor = false;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Pin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Phone Number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Username:";
            // 
            // text_Pin
            // 
            this.text_Pin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Pin.Location = new System.Drawing.Point(126, 316);
            this.text_Pin.Name = "text_Pin";
            this.text_Pin.Size = new System.Drawing.Size(312, 22);
            this.text_Pin.TabIndex = 21;
            // 
            // txt_Username
            // 
            this.txt_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Username.Location = new System.Drawing.Point(126, 143);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(312, 22);
            this.txt_Username.TabIndex = 19;
            this.txt_Username.TextChanged += new System.EventHandler(this.txt_Username_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 108);
            this.panel1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PET_HOSTEL.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(652, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "Payment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Amount:";
            // 
            // text_Amount
            // 
            this.text_Amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Amount.Location = new System.Drawing.Point(126, 200);
            this.text_Amount.Name = "text_Amount";
            this.text_Amount.Size = new System.Drawing.Size(312, 22);
            this.text_Amount.TabIndex = 26;
            // 
            // text_Card
            // 
            this.text_Card.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Card.Location = new System.Drawing.Point(126, 261);
            this.text_Card.Name = "text_Card";
            this.text_Card.Size = new System.Drawing.Size(312, 22);
            this.text_Card.TabIndex = 28;
            // 
            // button_Print
            // 
            this.button_Print.BackColor = System.Drawing.Color.DarkRed;
            this.button_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Print.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Print.ForeColor = System.Drawing.Color.White;
            this.button_Print.Location = new System.Drawing.Point(529, 143);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(133, 36);
            this.button_Print.TabIndex = 29;
            this.button_Print.Text = "Print Receipt";
            this.button_Print.UseVisualStyleBackColor = false;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(537, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 34);
            this.label6.TabIndex = 30;
            this.label6.Text = "Print receipt to get\r\nyour token";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // MobileBankingPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 430);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_Print);
            this.Controls.Add(this.text_Card);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_Pin);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_Amount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MobileBankingPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MobileBankingPayment";
            this.Load += new System.EventHandler(this.MobileBankingPayment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_Pin;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_Amount;
        private System.Windows.Forms.TextBox text_Card;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}