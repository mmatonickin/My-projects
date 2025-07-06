namespace MyDoc
{
    partial class FrmSetAppointment
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
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.lblAppointmentDate = new System.Windows.Forms.Label();
            this.txtSymptoms = new System.Windows.Forms.TextBox();
            this.lblZoomLink = new System.Windows.Forms.Label();
            this.txtZoomLink = new System.Windows.Forms.TextBox();
            this.lblPatientData = new System.Windows.Forms.Label();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtPatientSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOIB = new System.Windows.Forms.TextBox();
            this.lblSymptoms = new System.Windows.Forms.Label();
            this.lblAddAppointment = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPatientId
            // 
            this.txtPatientId.Location = new System.Drawing.Point(96, 70);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(133, 20);
            this.txtPatientId.TabIndex = 0;
            // 
            // lblPatientId
            // 
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Location = new System.Drawing.Point(29, 73);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(67, 13);
            this.lblPatientId.TabIndex = 1;
            this.lblPatientId.Text = "ID pacijenta:";
            // 
            // lblAppointmentDate
            // 
            this.lblAppointmentDate.AutoSize = true;
            this.lblAppointmentDate.Location = new System.Drawing.Point(68, 260);
            this.lblAppointmentDate.Name = "lblAppointmentDate";
            this.lblAppointmentDate.Size = new System.Drawing.Size(119, 13);
            this.lblAppointmentDate.TabIndex = 2;
            this.lblAppointmentDate.Text = "Datum i vrijeme termina:";
            // 
            // txtSymptoms
            // 
            this.txtSymptoms.Location = new System.Drawing.Point(330, 73);
            this.txtSymptoms.Multiline = true;
            this.txtSymptoms.Name = "txtSymptoms";
            this.txtSymptoms.Size = new System.Drawing.Size(162, 120);
            this.txtSymptoms.TabIndex = 3;
            // 
            // lblZoomLink
            // 
            this.lblZoomLink.AutoSize = true;
            this.lblZoomLink.Location = new System.Drawing.Point(131, 283);
            this.lblZoomLink.Name = "lblZoomLink";
            this.lblZoomLink.Size = new System.Drawing.Size(56, 13);
            this.lblZoomLink.TabIndex = 4;
            this.lblZoomLink.Text = "Zoom link:";
            // 
            // txtZoomLink
            // 
            this.txtZoomLink.Location = new System.Drawing.Point(193, 280);
            this.txtZoomLink.Name = "txtZoomLink";
            this.txtZoomLink.Size = new System.Drawing.Size(176, 20);
            this.txtZoomLink.TabIndex = 5;
            // 
            // lblPatientData
            // 
            this.lblPatientData.AutoSize = true;
            this.lblPatientData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPatientData.Location = new System.Drawing.Point(189, 21);
            this.lblPatientData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPatientData.Name = "lblPatientData";
            this.lblPatientData.Size = new System.Drawing.Size(138, 20);
            this.lblPatientData.TabIndex = 6;
            this.lblPatientData.Text = "Podaci o pacijentu";
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Location = new System.Drawing.Point(193, 332);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(176, 32);
            this.btnAddAppointment.TabIndex = 7;
            this.btnAddAppointment.Text = "Dodaj termin";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(417, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Odustani";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(23, 95);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(73, 13);
            this.lblPatientName.TabIndex = 9;
            this.lblPatientName.Text = "Ime pacijenta:";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(96, 95);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(133, 20);
            this.txtPatientName.TabIndex = 10;
            // 
            // txtPatientSurname
            // 
            this.txtPatientSurname.Location = new System.Drawing.Point(96, 121);
            this.txtPatientSurname.Name = "txtPatientSurname";
            this.txtPatientSurname.Size = new System.Drawing.Size(133, 20);
            this.txtPatientSurname.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Prezime pacijenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "OIB pacijenta:";
            // 
            // txtOIB
            // 
            this.txtOIB.Location = new System.Drawing.Point(96, 173);
            this.txtOIB.Name = "txtOIB";
            this.txtOIB.Size = new System.Drawing.Size(133, 20);
            this.txtOIB.TabIndex = 14;
            // 
            // lblSymptoms
            // 
            this.lblSymptoms.AutoSize = true;
            this.lblSymptoms.Location = new System.Drawing.Point(235, 73);
            this.lblSymptoms.Name = "lblSymptoms";
            this.lblSymptoms.Size = new System.Drawing.Size(91, 13);
            this.lblSymptoms.TabIndex = 15;
            this.lblSymptoms.Text = "Simptomi / razlog:";
            // 
            // lblAddAppointment
            // 
            this.lblAddAppointment.AutoSize = true;
            this.lblAddAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAddAppointment.Location = new System.Drawing.Point(181, 218);
            this.lblAddAppointment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddAppointment.Name = "lblAddAppointment";
            this.lblAddAppointment.Size = new System.Drawing.Size(124, 20);
            this.lblAddAppointment.TabIndex = 16;
            this.lblAddAppointment.Text = "Dodjela termina:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(193, 254);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 20);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(96, 147);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(133, 20);
            this.txtEmail.TabIndex = 18;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(81, 13);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "Email pacijenta:";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(193, 306);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(176, 20);
            this.txtDoctor.TabIndex = 20;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(102, 309);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(85, 13);
            this.lblDoctor.TabIndex = 21;
            this.lblDoctor.Text = "Dodijelio liječnik:";
            // 
            // FrmSetAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 431);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblAddAppointment);
            this.Controls.Add(this.lblSymptoms);
            this.Controls.Add(this.txtOIB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPatientSurname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.lblPatientData);
            this.Controls.Add(this.txtZoomLink);
            this.Controls.Add(this.lblZoomLink);
            this.Controls.Add(this.txtSymptoms);
            this.Controls.Add(this.lblAppointmentDate);
            this.Controls.Add(this.lblPatientId);
            this.Controls.Add(this.txtPatientId);
            this.Name = "FrmSetAppointment";
            this.Text = "FrmSetAppointment";
            this.Load += new System.EventHandler(this.FrmSetAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.Label lblAppointmentDate;
        private System.Windows.Forms.TextBox txtSymptoms;
        private System.Windows.Forms.Label lblZoomLink;
        private System.Windows.Forms.TextBox txtZoomLink;
        private System.Windows.Forms.Label lblPatientData;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Label lblPatientName;
        public System.Windows.Forms.TextBox txtPatientName;
        public System.Windows.Forms.TextBox txtPatientSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtOIB;
        private System.Windows.Forms.Label lblSymptoms;
        private System.Windows.Forms.Label lblAddAppointment;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Label lblDoctor;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}