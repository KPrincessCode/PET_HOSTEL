namespace PET_HOSTEL
{
    partial class Changepasss
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.npass = new System.Windows.Forms.TextBox();
            this.cpass = new System.Windows.Forms.TextBox();
            this.updt = new System.Windows.Forms.Button();
            this.sp = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm password";
            // 
            // npass
            // 
            this.npass.Location = new System.Drawing.Point(263, 131);
            this.npass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.npass.Multiline = true;
            this.npass.Name = "npass";
            this.npass.PasswordChar = '*';
            this.npass.Size = new System.Drawing.Size(277, 30);
            this.npass.TabIndex = 2;
            this.npass.TextChanged += new System.EventHandler(this.npass_TextChanged);
            // 
            // cpass
            // 
            this.cpass.Location = new System.Drawing.Point(263, 191);
            this.cpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cpass.Multiline = true;
            this.cpass.Name = "cpass";
            this.cpass.PasswordChar = '*';
            this.cpass.Size = new System.Drawing.Size(276, 28);
            this.cpass.TabIndex = 3;
            // 
            // updt
            // 
            this.updt.BackColor = System.Drawing.Color.Turquoise;
            this.updt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updt.ForeColor = System.Drawing.Color.Black;
            this.updt.Location = new System.Drawing.Point(389, 280);
            this.updt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updt.Name = "updt";
            this.updt.Size = new System.Drawing.Size(147, 38);
            this.updt.TabIndex = 4;
            this.updt.Text = "Update";
            this.updt.UseVisualStyleBackColor = false;
            this.updt.Click += new System.EventHandler(this.updt_Click);
            // 
            // sp
            // 
            this.sp.AutoSize = true;
            this.sp.Location = new System.Drawing.Point(407, 234);
            this.sp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sp.Name = "sp";
            this.sp.Size = new System.Drawing.Size(129, 21);
            this.sp.TabIndex = 5;
            this.sp.Text = "Show Password";
            this.sp.UseVisualStyleBackColor = true;
            this.sp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 56);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Change Password";
            // 
            // Changepasss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sp);
            this.Controls.Add(this.updt);
            this.Controls.Add(this.cpass);
            this.Controls.Add(this.npass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Changepasss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changepasss";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox npass;
        private System.Windows.Forms.TextBox cpass;
        private System.Windows.Forms.Button updt;
        private System.Windows.Forms.CheckBox sp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}