namespace WindowsFormsApp1
{
    partial class FrmLoginDoctor
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.lblRegistration = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLoginDoctor = new System.Windows.Forms.Label();
            this.txtLicenceNumber = new System.Windows.Forms.TextBox();
            this.lblLicenceNumber = new System.Windows.Forms.Label();
            this.btnLoginDoctor = new System.Windows.Forms.Button();
            this.pbDoctor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoctor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(114, 288);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 28);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Natrag";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(196, 288);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Zatvori";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Location = new System.Drawing.Point(138, 206);
            this.lnkLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(98, 13);
            this.lnkLogin.TabIndex = 4;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "REGISTRIRAJ SE!";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // lblRegistration
            // 
            this.lblRegistration.AutoSize = true;
            this.lblRegistration.Location = new System.Drawing.Point(11, 206);
            this.lblRegistration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistration.Name = "lblRegistration";
            this.lblRegistration.Size = new System.Drawing.Size(123, 13);
            this.lblRegistration.TabIndex = 52;
            this.lblRegistration.Text = "Nemaš korisnički račun?";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 184);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(127, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(109, 132);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(127, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(62, 187);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(47, 13);
            this.lblPassword.TabIndex = 49;
            this.lblPassword.Text = "Lozinka:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(31, 134);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(78, 13);
            this.lblUsername.TabIndex = 48;
            this.lblUsername.Text = "Korisničko ime:";
            // 
            // lblLoginDoctor
            // 
            this.lblLoginDoctor.AutoSize = true;
            this.lblLoginDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLoginDoctor.Location = new System.Drawing.Point(92, 23);
            this.lblLoginDoctor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoginDoctor.Name = "lblLoginDoctor";
            this.lblLoginDoctor.Size = new System.Drawing.Size(91, 16);
            this.lblLoginDoctor.TabIndex = 47;
            this.lblLoginDoctor.Text = "Prijava-doktor";
            // 
            // txtLicenceNumber
            // 
            this.txtLicenceNumber.Location = new System.Drawing.Point(109, 156);
            this.txtLicenceNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtLicenceNumber.Name = "txtLicenceNumber";
            this.txtLicenceNumber.Size = new System.Drawing.Size(127, 20);
            this.txtLicenceNumber.TabIndex = 2;
            this.txtLicenceNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenceNumber_KeyPress);
            // 
            // lblLicenceNumber
            // 
            this.lblLicenceNumber.AutoSize = true;
            this.lblLicenceNumber.Location = new System.Drawing.Point(44, 159);
            this.lblLicenceNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLicenceNumber.Name = "lblLicenceNumber";
            this.lblLicenceNumber.Size = new System.Drawing.Size(65, 13);
            this.lblLicenceNumber.TabIndex = 59;
            this.lblLicenceNumber.Text = "Broj licence:";
            // 
            // btnLoginDoctor
            // 
            this.btnLoginDoctor.Location = new System.Drawing.Point(111, 237);
            this.btnLoginDoctor.Name = "btnLoginDoctor";
            this.btnLoginDoctor.Size = new System.Drawing.Size(125, 30);
            this.btnLoginDoctor.TabIndex = 5;
            this.btnLoginDoctor.Text = "Prijavi se";
            this.btnLoginDoctor.UseVisualStyleBackColor = true;
            this.btnLoginDoctor.Click += new System.EventHandler(this.btnLoginDoctor_Click);
            // 
            // pbDoctor
            // 
            this.pbDoctor.Image = global::MyDoc.Properties.Resources.doctor_921059;
            this.pbDoctor.Location = new System.Drawing.Point(109, 51);
            this.pbDoctor.Name = "pbDoctor";
            this.pbDoctor.Size = new System.Drawing.Size(54, 56);
            this.pbDoctor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDoctor.TabIndex = 60;
            this.pbDoctor.TabStop = false;
            // 
            // FrmLoginDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 320);
            this.Controls.Add(this.pbDoctor);
            this.Controls.Add(this.btnLoginDoctor);
            this.Controls.Add(this.txtLicenceNumber);
            this.Controls.Add(this.lblLicenceNumber);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lnkLogin);
            this.Controls.Add(this.lblRegistration);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLoginDoctor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmLoginDoctor";
            this.Text = "FrmLoginDoctor";
            ((System.ComponentModel.ISupportInitialize)(this.pbDoctor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lnkLogin;
        private System.Windows.Forms.Label lblRegistration;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLoginDoctor;
        private System.Windows.Forms.TextBox txtLicenceNumber;
        private System.Windows.Forms.Label lblLicenceNumber;
        private System.Windows.Forms.Button btnLoginDoctor;
        private System.Windows.Forms.PictureBox pbDoctor;
    }
}