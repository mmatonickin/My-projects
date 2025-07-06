namespace WindowsFormsApp1
{
    partial class FrmLoginPatient
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
            this.lblLoginPatient = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.lblRegistration = new System.Windows.Forms.Label();
            this.btnLoginPatient = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbPatient = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoginPatient
            // 
            this.lblLoginPatient.AutoSize = true;
            this.lblLoginPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLoginPatient.Location = new System.Drawing.Point(86, 20);
            this.lblLoginPatient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoginPatient.Name = "lblLoginPatient";
            this.lblLoginPatient.Size = new System.Drawing.Size(100, 16);
            this.lblLoginPatient.TabIndex = 0;
            this.lblLoginPatient.Text = "Prijava-pacijent";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(40, 140);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(78, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Korisničko ime:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(70, 167);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(47, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Lozinka:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(117, 137);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(114, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(117, 164);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(114, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Location = new System.Drawing.Point(133, 193);
            this.lnkLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(98, 13);
            this.lnkLogin.TabIndex = 3;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "REGISTRIRAJ SE!";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // lblRegistration
            // 
            this.lblRegistration.AutoSize = true;
            this.lblRegistration.Location = new System.Drawing.Point(12, 193);
            this.lblRegistration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistration.Name = "lblRegistration";
            this.lblRegistration.Size = new System.Drawing.Size(123, 13);
            this.lblRegistration.TabIndex = 38;
            this.lblRegistration.Text = "Nemaš korisnički račun?";
            // 
            // btnLoginPatient
            // 
            this.btnLoginPatient.Location = new System.Drawing.Point(123, 217);
            this.btnLoginPatient.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoginPatient.Name = "btnLoginPatient";
            this.btnLoginPatient.Size = new System.Drawing.Size(108, 37);
            this.btnLoginPatient.TabIndex = 4;
            this.btnLoginPatient.Text = "Prijavi se";
            this.btnLoginPatient.UseVisualStyleBackColor = true;
            this.btnLoginPatient.Click += new System.EventHandler(this.btnLoginPatient_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(117, 290);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 28);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Natrag";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(198, 290);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Zatvori";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbPatient
            // 
            this.pbPatient.Image = global::MyDoc.Properties.Resources.hospitalisation_2302715;
            this.pbPatient.Location = new System.Drawing.Point(106, 49);
            this.pbPatient.Name = "pbPatient";
            this.pbPatient.Size = new System.Drawing.Size(56, 60);
            this.pbPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPatient.TabIndex = 39;
            this.pbPatient.TabStop = false;
            // 
            // FrmLoginPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 320);
            this.Controls.Add(this.pbPatient);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoginPatient);
            this.Controls.Add(this.lnkLogin);
            this.Controls.Add(this.lblRegistration);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLoginPatient);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmLoginPatient";
            this.Text = "FrmLoginPatient";
            ((System.ComponentModel.ISupportInitialize)(this.pbPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginPatient;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel lnkLogin;
        private System.Windows.Forms.Label lblRegistration;
        private System.Windows.Forms.Button btnLoginPatient;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbPatient;
    }
}