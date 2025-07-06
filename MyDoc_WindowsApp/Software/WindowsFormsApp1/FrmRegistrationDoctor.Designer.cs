namespace WindowsFormsApp1
{
    partial class FrmRegistrationDoctor
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
            this.lblDoctorRegistration = new System.Windows.Forms.Label();
            this.btnRegisterPatient = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLicenceNum = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLicenceNumber = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbleEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDoctorRegistration
            // 
            this.lblDoctorRegistration.AutoSize = true;
            this.lblDoctorRegistration.Location = new System.Drawing.Point(110, 41);
            this.lblDoctorRegistration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoctorRegistration.Name = "lblDoctorRegistration";
            this.lblDoctorRegistration.Size = new System.Drawing.Size(95, 13);
            this.lblDoctorRegistration.TabIndex = 43;
            this.lblDoctorRegistration.Text = "Registracija-doktor";
            // 
            // btnRegisterPatient
            // 
            this.btnRegisterPatient.Location = new System.Drawing.Point(128, 279);
            this.btnRegisterPatient.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegisterPatient.Name = "btnRegisterPatient";
            this.btnRegisterPatient.Size = new System.Drawing.Size(108, 37);
            this.btnRegisterPatient.TabIndex = 8;
            this.btnRegisterPatient.Text = "Registriraj se";
            this.btnRegisterPatient.UseVisualStyleBackColor = true;
            this.btnRegisterPatient.Click += new System.EventHandler(this.btnRegisterPatient_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(113, 332);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 28);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Natrag";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(195, 332);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 28);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Zatvori";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Location = new System.Drawing.Point(186, 255);
            this.lnkLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(67, 13);
            this.lnkLogin.TabIndex = 7;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "PRIJAVI SE!";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(58, 255);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(133, 13);
            this.lblLogin.TabIndex = 36;
            this.lblLogin.Text = "Već imaš korisnički račun?";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(128, 136);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(2);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(119, 20);
            this.txtSurname.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 106);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(119, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtLicenceNum
            // 
            this.txtLicenceNum.Location = new System.Drawing.Point(128, 77);
            this.txtLicenceNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtLicenceNum.Name = "txtLicenceNum";
            this.txtLicenceNum.Size = new System.Drawing.Size(119, 20);
            this.txtLicenceNum.TabIndex = 1;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(79, 139);
            this.lblSurname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(47, 13);
            this.lblSurname.TabIndex = 24;
            this.lblSurname.Text = "Prezime:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(99, 109);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(27, 13);
            this.lblName.TabIndex = 23;
            this.lblName.Text = "Ime:";
            // 
            // lblLicenceNumber
            // 
            this.lblLicenceNumber.AutoSize = true;
            this.lblLicenceNumber.Location = new System.Drawing.Point(63, 80);
            this.lblLicenceNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLicenceNumber.Name = "lblLicenceNumber";
            this.lblLicenceNumber.Size = new System.Drawing.Size(65, 13);
            this.lblLicenceNumber.TabIndex = 22;
            this.lblLicenceNumber.Text = "Broj licence:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(50, 202);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(78, 13);
            this.lblUsername.TabIndex = 44;
            this.lblUsername.Text = "Korisničko ime:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(81, 232);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(47, 13);
            this.lblPassword.TabIndex = 45;
            this.lblPassword.Text = "Lozinka:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(128, 230);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(119, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(128, 200);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(119, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(128, 169);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(119, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // lbleEmail
            // 
            this.lbleEmail.AutoSize = true;
            this.lbleEmail.Location = new System.Drawing.Point(89, 172);
            this.lbleEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbleEmail.Name = "lbleEmail";
            this.lbleEmail.Size = new System.Drawing.Size(35, 13);
            this.lbleEmail.TabIndex = 49;
            this.lbleEmail.Text = "Email:";
            // 
            // FrmRegistrationDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(280, 371);
            this.Controls.Add(this.lbleEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblDoctorRegistration);
            this.Controls.Add(this.btnRegisterPatient);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lnkLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtLicenceNum);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLicenceNumber);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmRegistrationDoctor";
            this.Text = "FrmRegistrationDoctor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDoctorRegistration;
        private System.Windows.Forms.Button btnRegisterPatient;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lnkLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLicenceNum;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLicenceNumber;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbleEmail;
    }
}