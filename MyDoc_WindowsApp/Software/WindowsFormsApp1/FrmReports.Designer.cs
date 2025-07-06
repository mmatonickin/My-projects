namespace MyDoc
{
    partial class FrmReports
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSendReport = new System.Windows.Forms.Button();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblPatientSurname = new System.Windows.Forms.Label();
            this.lblPatientOib = new System.Windows.Forms.Label();
            this.lblPatientEmail = new System.Windows.Forms.Label();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtPatientSurname = new System.Windows.Forms.TextBox();
            this.txtPatientOib = new System.Windows.Forms.TextBox();
            this.txtPatientEmail = new System.Windows.Forms.TextBox();
            this.txtSymptoms = new System.Windows.Forms.TextBox();
            this.lblTherapy = new System.Windows.Forms.Label();
            this.txtTherapy = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(442, 313);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Zatvori";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSendReport
            // 
            this.btnSendReport.Location = new System.Drawing.Point(129, 313);
            this.btnSendReport.Name = "btnSendReport";
            this.btnSendReport.Size = new System.Drawing.Size(124, 25);
            this.btnSendReport.TabIndex = 1;
            this.btnSendReport.Text = "Pošalji nalaz";
            this.btnSendReport.UseVisualStyleBackColor = true;
            this.btnSendReport.Click += new System.EventHandler(this.btnSendReport_Click);
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblReport.Location = new System.Drawing.Point(237, 9);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(94, 29);
            this.lblReport.TabIndex = 2;
            this.lblReport.Text = "NALAZI";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPatientName.Location = new System.Drawing.Point(33, 86);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(90, 16);
            this.lblPatientName.TabIndex = 4;
            this.lblPatientName.Text = "Ime pacijenta:";
            // 
            // lblPatientSurname
            // 
            this.lblPatientSurname.AutoSize = true;
            this.lblPatientSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPatientSurname.Location = new System.Drawing.Point(6, 116);
            this.lblPatientSurname.Name = "lblPatientSurname";
            this.lblPatientSurname.Size = new System.Drawing.Size(117, 16);
            this.lblPatientSurname.TabIndex = 5;
            this.lblPatientSurname.Text = "Prezime pacijenta:";
            // 
            // lblPatientOib
            // 
            this.lblPatientOib.AutoSize = true;
            this.lblPatientOib.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPatientOib.Location = new System.Drawing.Point(33, 148);
            this.lblPatientOib.Name = "lblPatientOib";
            this.lblPatientOib.Size = new System.Drawing.Size(90, 16);
            this.lblPatientOib.TabIndex = 6;
            this.lblPatientOib.Text = "OIB pacijenta:";
            // 
            // lblPatientEmail
            // 
            this.lblPatientEmail.AutoSize = true;
            this.lblPatientEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPatientEmail.Location = new System.Drawing.Point(24, 184);
            this.lblPatientEmail.Name = "lblPatientEmail";
            this.lblPatientEmail.Size = new System.Drawing.Size(102, 16);
            this.lblPatientEmail.TabIndex = 7;
            this.lblPatientEmail.Text = "Email pacijenta:";
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDiagnosis.Location = new System.Drawing.Point(292, 58);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(71, 16);
            this.lblDiagnosis.TabIndex = 8;
            this.lblDiagnosis.Text = "Dijagnoza:";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(129, 86);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(124, 20);
            this.txtPatientName.TabIndex = 10;
            // 
            // txtPatientSurname
            // 
            this.txtPatientSurname.Location = new System.Drawing.Point(129, 116);
            this.txtPatientSurname.Name = "txtPatientSurname";
            this.txtPatientSurname.Size = new System.Drawing.Size(124, 20);
            this.txtPatientSurname.TabIndex = 11;
            // 
            // txtPatientOib
            // 
            this.txtPatientOib.Location = new System.Drawing.Point(129, 148);
            this.txtPatientOib.Name = "txtPatientOib";
            this.txtPatientOib.Size = new System.Drawing.Size(124, 20);
            this.txtPatientOib.TabIndex = 12;
            // 
            // txtPatientEmail
            // 
            this.txtPatientEmail.Location = new System.Drawing.Point(129, 183);
            this.txtPatientEmail.Name = "txtPatientEmail";
            this.txtPatientEmail.Size = new System.Drawing.Size(124, 20);
            this.txtPatientEmail.TabIndex = 13;
            // 
            // txtSymptoms
            // 
            this.txtSymptoms.Location = new System.Drawing.Point(295, 86);
            this.txtSymptoms.Multiline = true;
            this.txtSymptoms.Name = "txtSymptoms";
            this.txtSymptoms.Size = new System.Drawing.Size(267, 82);
            this.txtSymptoms.TabIndex = 14;
            // 
            // lblTherapy
            // 
            this.lblTherapy.AutoSize = true;
            this.lblTherapy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTherapy.Location = new System.Drawing.Point(292, 188);
            this.lblTherapy.Name = "lblTherapy";
            this.lblTherapy.Size = new System.Drawing.Size(61, 16);
            this.lblTherapy.TabIndex = 15;
            this.lblTherapy.Text = "Terapija:";
            // 
            // txtTherapy
            // 
            this.txtTherapy.Location = new System.Drawing.Point(295, 216);
            this.txtTherapy.Multiline = true;
            this.txtTherapy.Name = "txtTherapy";
            this.txtTherapy.Size = new System.Drawing.Size(267, 82);
            this.txtTherapy.TabIndex = 16;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDate.Location = new System.Drawing.Point(74, 223);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 16);
            this.lblDate.TabIndex = 17;
            this.lblDate.Text = "Datum:";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDoctor.Location = new System.Drawing.Point(70, 267);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(53, 16);
            this.lblDoctor.TabIndex = 19;
            this.lblDoctor.Text = "Poslao:";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(129, 267);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(124, 20);
            this.txtDoctor.TabIndex = 20;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(129, 223);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(124, 20);
            this.txtDate.TabIndex = 21;
            // 
            // FrmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 350);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtTherapy);
            this.Controls.Add(this.lblTherapy);
            this.Controls.Add(this.txtSymptoms);
            this.Controls.Add(this.txtPatientEmail);
            this.Controls.Add(this.txtPatientOib);
            this.Controls.Add(this.txtPatientSurname);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblDiagnosis);
            this.Controls.Add(this.lblPatientEmail);
            this.Controls.Add(this.lblPatientOib);
            this.Controls.Add(this.lblPatientSurname);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.btnSendReport);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmReports";
            this.Text = "FrmReports";
            this.Load += new System.EventHandler(this.FrmReports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSendReport;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientSurname;
        private System.Windows.Forms.Label lblPatientOib;
        private System.Windows.Forms.Label lblPatientEmail;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtPatientSurname;
        private System.Windows.Forms.TextBox txtPatientOib;
        private System.Windows.Forms.TextBox txtPatientEmail;
        private System.Windows.Forms.TextBox txtSymptoms;
        private System.Windows.Forms.Label lblTherapy;
        private System.Windows.Forms.TextBox txtTherapy;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.TextBox txtDate;
    }
}