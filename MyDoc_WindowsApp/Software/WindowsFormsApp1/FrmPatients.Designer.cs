namespace WindowsFormsApp1
{
    partial class FrmPatients
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenuControl = new System.Windows.Forms.Panel();
            this.lblDocApp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAppointment = new System.Windows.Forms.Button();
            this.btnMyPackage = new System.Windows.Forms.Button();
            this.btnServiceBuy = new System.Windows.Forms.Button();
            this.btnBuyPackage = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.reportView1 = new MyDoc.ReportView();
            this.appointmentView1 = new MyDoc.AppointmentView();
            this.buyService1 = new MyDoc.BuyService();
            this.buyPackage1 = new MyDoc.BuyPackage();
            this.basicPaket1 = new MyDoc.BasicPaket();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(0, 431);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(213, 46);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Izlaz";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMenu.Controls.Add(this.pnlMenuControl);
            this.pnlMenu.Controls.Add(this.lblDocApp);
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Controls.Add(this.btnAppointment);
            this.pnlMenu.Controls.Add(this.btnClose);
            this.pnlMenu.Controls.Add(this.btnMyPackage);
            this.pnlMenu.Controls.Add(this.btnServiceBuy);
            this.pnlMenu.Controls.Add(this.btnBuyPackage);
            this.pnlMenu.Controls.Add(this.btnReport);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(222, 488);
            this.pnlMenu.TabIndex = 1;
            // 
            // pnlMenuControl
            // 
            this.pnlMenuControl.BackColor = System.Drawing.Color.DimGray;
            this.pnlMenuControl.Location = new System.Drawing.Point(200, 136);
            this.pnlMenuControl.Name = "pnlMenuControl";
            this.pnlMenuControl.Size = new System.Drawing.Size(13, 46);
            this.pnlMenuControl.TabIndex = 6;
            // 
            // lblDocApp
            // 
            this.lblDocApp.AutoSize = true;
            this.lblDocApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDocApp.Location = new System.Drawing.Point(72, 85);
            this.lblDocApp.Name = "lblDocApp";
            this.lblDocApp.Size = new System.Drawing.Size(62, 20);
            this.lblDocApp.TabIndex = 5;
            this.lblDocApp.Text = "My Doc";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDoc.Properties.Resources.medical_team;
            this.pictureBox1.Location = new System.Drawing.Point(67, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnAppointment
            // 
            this.btnAppointment.Location = new System.Drawing.Point(0, 292);
            this.btnAppointment.Name = "btnAppointment";
            this.btnAppointment.Size = new System.Drawing.Size(215, 46);
            this.btnAppointment.TabIndex = 3;
            this.btnAppointment.Text = "Termini";
            this.btnAppointment.UseVisualStyleBackColor = true;
            this.btnAppointment.Click += new System.EventHandler(this.btnAppointment_Click);
            // 
            // btnMyPackage
            // 
            this.btnMyPackage.Location = new System.Drawing.Point(0, 240);
            this.btnMyPackage.Name = "btnMyPackage";
            this.btnMyPackage.Size = new System.Drawing.Size(215, 46);
            this.btnMyPackage.TabIndex = 2;
            this.btnMyPackage.Text = "Moji paketi";
            this.btnMyPackage.UseVisualStyleBackColor = true;
            this.btnMyPackage.Click += new System.EventHandler(this.btnMyPackage_Click);
            // 
            // btnServiceBuy
            // 
            this.btnServiceBuy.Location = new System.Drawing.Point(0, 188);
            this.btnServiceBuy.Name = "btnServiceBuy";
            this.btnServiceBuy.Size = new System.Drawing.Size(215, 46);
            this.btnServiceBuy.TabIndex = 1;
            this.btnServiceBuy.Text = "Kupnja Usluga";
            this.btnServiceBuy.UseVisualStyleBackColor = true;
            this.btnServiceBuy.Click += new System.EventHandler(this.btnServiceBuy_Click);
            // 
            // btnBuyPackage
            // 
            this.btnBuyPackage.Location = new System.Drawing.Point(0, 136);
            this.btnBuyPackage.Name = "btnBuyPackage";
            this.btnBuyPackage.Size = new System.Drawing.Size(215, 46);
            this.btnBuyPackage.TabIndex = 0;
            this.btnBuyPackage.Text = "Kupnja paketa";
            this.btnBuyPackage.UseVisualStyleBackColor = true;
            this.btnBuyPackage.Click += new System.EventHandler(this.btnBuyPackage_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(0, 344);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(215, 46);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Nalazi";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // reportView1
            // 
            this.reportView1.BackColor = System.Drawing.Color.Silver;
            this.reportView1.Location = new System.Drawing.Point(221, 0);
            this.reportView1.Name = "reportView1";
            this.reportView1.Size = new System.Drawing.Size(922, 488);
            this.reportView1.TabIndex = 5;
            // 
            // appointmentView1
            // 
            this.appointmentView1.BackColor = System.Drawing.Color.Silver;
            this.appointmentView1.Location = new System.Drawing.Point(221, 3);
            this.appointmentView1.Name = "appointmentView1";
            this.appointmentView1.Size = new System.Drawing.Size(922, 485);
            this.appointmentView1.TabIndex = 4;
            // 
            // buyService1
            // 
            this.buyService1.BackColor = System.Drawing.Color.Silver;
            this.buyService1.Location = new System.Drawing.Point(221, 0);
            this.buyService1.Name = "buyService1";
            this.buyService1.Size = new System.Drawing.Size(926, 488);
            this.buyService1.TabIndex = 3;
            // 
            // buyPackage1
            // 
            this.buyPackage1.BackColor = System.Drawing.Color.Silver;
            this.buyPackage1.Location = new System.Drawing.Point(221, 3);
            this.buyPackage1.Name = "buyPackage1";
            this.buyPackage1.Size = new System.Drawing.Size(926, 488);
            this.buyPackage1.TabIndex = 2;
            // 
            // basicPaket1
            // 
            this.basicPaket1.BackColor = System.Drawing.Color.Silver;
            this.basicPaket1.Location = new System.Drawing.Point(219, 24);
            this.basicPaket1.Name = "basicPaket1";
            this.basicPaket1.Size = new System.Drawing.Size(922, 467);
            this.basicPaket1.TabIndex = 6;
            // 
            // FrmPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 488);
            this.Controls.Add(this.basicPaket1);
            this.Controls.Add(this.reportView1);
            this.Controls.Add(this.appointmentView1);
            this.Controls.Add(this.buyService1);
            this.Controls.Add(this.buyPackage1);
            this.Controls.Add(this.pnlMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPatients";
            this.Text = "FrmPatients";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnServiceBuy;
        private System.Windows.Forms.Button btnBuyPackage;
        private System.Windows.Forms.Button btnAppointment;
        private System.Windows.Forms.Button btnMyPackage;
        private MyDoc.BuyPackage buyPackage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDocApp;
        private System.Windows.Forms.Panel pnlMenuControl;
        private MyDoc.BuyService buyService1;
        private System.Windows.Forms.Button btnReport;
        private MyDoc.AppointmentView appointmentView1;
        private MyDoc.ReportView reportView1;
        private MyDoc.BasicPaket basicPaket1;
    }
}