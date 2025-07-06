namespace WindowsFormsApp1
{
    partial class FrmDoctors
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenuControl2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnPatients = new System.Windows.Forms.Button();
            this.lblDocApp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.viewPatients1 = new MyDoc.ViewPatients();
            this.setAppointment1 = new MyDoc.SetAppointment();
            this.reports1 = new MyDoc.Reports();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMenu.Controls.Add(this.pnlMenuControl2);
            this.pnlMenu.Controls.Add(this.btnExit);
            this.pnlMenu.Controls.Add(this.btnAppointments);
            this.pnlMenu.Controls.Add(this.btnReports);
            this.pnlMenu.Controls.Add(this.btnPatients);
            this.pnlMenu.Controls.Add(this.lblDocApp);
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(222, 488);
            this.pnlMenu.TabIndex = 2;
            // 
            // pnlMenuControl2
            // 
            this.pnlMenuControl2.BackColor = System.Drawing.Color.DimGray;
            this.pnlMenuControl2.Location = new System.Drawing.Point(202, 152);
            this.pnlMenuControl2.Name = "pnlMenuControl2";
            this.pnlMenuControl2.Size = new System.Drawing.Size(13, 46);
            this.pnlMenuControl2.TabIndex = 11;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(0, 439);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(215, 46);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Izlaz";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.Location = new System.Drawing.Point(0, 256);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(215, 46);
            this.btnAppointments.TabIndex = 9;
            this.btnAppointments.Text = "Termini";
            this.btnAppointments.UseVisualStyleBackColor = true;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(0, 204);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(215, 46);
            this.btnReports.TabIndex = 8;
            this.btnReports.Text = "Nalazi";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnPatients
            // 
            this.btnPatients.Location = new System.Drawing.Point(0, 152);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(215, 46);
            this.btnPatients.TabIndex = 7;
            this.btnPatients.Text = "Pacijenti";
            this.btnPatients.UseVisualStyleBackColor = true;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // lblDocApp
            // 
            this.lblDocApp.AutoSize = true;
            this.lblDocApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDocApp.Location = new System.Drawing.Point(78, 85);
            this.lblDocApp.Name = "lblDocApp";
            this.lblDocApp.Size = new System.Drawing.Size(62, 20);
            this.lblDocApp.TabIndex = 6;
            this.lblDocApp.Text = "My Doc";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDoc.Properties.Resources.medical_team;
            this.pictureBox1.Location = new System.Drawing.Point(73, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // viewPatients1
            // 
            this.viewPatients1.BackColor = System.Drawing.Color.Silver;
            this.viewPatients1.Location = new System.Drawing.Point(221, -19);
            this.viewPatients1.Name = "viewPatients1";
            this.viewPatients1.Size = new System.Drawing.Size(922, 507);
            this.viewPatients1.TabIndex = 3;
            // 
            // setAppointment1
            // 
            this.setAppointment1.BackColor = System.Drawing.Color.Silver;
            this.setAppointment1.Location = new System.Drawing.Point(221, 0);
            this.setAppointment1.Name = "setAppointment1";
            this.setAppointment1.Size = new System.Drawing.Size(922, 488);
            this.setAppointment1.TabIndex = 4;
            // 
            // reports1
            // 
            this.reports1.BackColor = System.Drawing.Color.Silver;
            this.reports1.Location = new System.Drawing.Point(221, -3);
            this.reports1.Name = "reports1";
            this.reports1.Size = new System.Drawing.Size(922, 488);
            this.reports1.TabIndex = 5;
            // 
            // FrmDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 488);
            this.Controls.Add(this.viewPatients1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.reports1);
            this.Controls.Add(this.setAppointment1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDoctors";
            this.Text = "FrmDoctors";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDocApp;
        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Panel pnlMenuControl2;
        private MyDoc.ViewPatients viewPatients1;
        private MyDoc.SetAppointment setAppointment1;
        private MyDoc.Reports reports1;
    }
}