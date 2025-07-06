namespace MyDoc
{
    partial class FrmAppointmentRequest
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
            this.lblAppointmentReq = new System.Windows.Forms.Label();
            this.lblSymptoms = new System.Windows.Forms.Label();
            this.lblInputDate = new System.Windows.Forms.Label();
            this.txtSymptoms = new System.Windows.Forms.RichTextBox();
            this.txtInputDate = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAppointmentReq
            // 
            this.lblAppointmentReq.AutoSize = true;
            this.lblAppointmentReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAppointmentReq.Location = new System.Drawing.Point(55, 13);
            this.lblAppointmentReq.Name = "lblAppointmentReq";
            this.lblAppointmentReq.Size = new System.Drawing.Size(300, 20);
            this.lblAppointmentReq.TabIndex = 0;
            this.lblAppointmentReq.Text = "ZAHTJEV ZA TERMIN / VAĐENJE KRVI";
            // 
            // lblSymptoms
            // 
            this.lblSymptoms.AutoSize = true;
            this.lblSymptoms.Location = new System.Drawing.Point(9, 51);
            this.lblSymptoms.Name = "lblSymptoms";
            this.lblSymptoms.Size = new System.Drawing.Size(181, 13);
            this.lblSymptoms.TabIndex = 1;
            this.lblSymptoms.Text = "Simptomi / zahtjev za vađenjem krvi:";
            // 
            // lblInputDate
            // 
            this.lblInputDate.AutoSize = true;
            this.lblInputDate.Location = new System.Drawing.Point(9, 191);
            this.lblInputDate.Name = "lblInputDate";
            this.lblInputDate.Size = new System.Drawing.Size(73, 13);
            this.lblInputDate.TabIndex = 2;
            this.lblInputDate.Text = "Datum unosa:";
            // 
            // txtSymptoms
            // 
            this.txtSymptoms.Location = new System.Drawing.Point(12, 67);
            this.txtSymptoms.Name = "txtSymptoms";
            this.txtSymptoms.Size = new System.Drawing.Size(385, 112);
            this.txtSymptoms.TabIndex = 3;
            this.txtSymptoms.Text = "";
            // 
            // txtInputDate
            // 
            this.txtInputDate.Location = new System.Drawing.Point(88, 188);
            this.txtInputDate.Name = "txtInputDate";
            this.txtInputDate.ReadOnly = true;
            this.txtInputDate.Size = new System.Drawing.Size(116, 20);
            this.txtInputDate.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(272, 186);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(125, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Predaj zahtjev";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FrmAppointmentRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 218);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInputDate);
            this.Controls.Add(this.txtSymptoms);
            this.Controls.Add(this.lblInputDate);
            this.Controls.Add(this.lblSymptoms);
            this.Controls.Add(this.lblAppointmentReq);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAppointmentRequest";
            this.Text = "FrmAppointmentRequest";
            this.Load += new System.EventHandler(this.FrmAppointmentRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppointmentReq;
        private System.Windows.Forms.Label lblSymptoms;
        private System.Windows.Forms.Label lblInputDate;
        private System.Windows.Forms.RichTextBox txtSymptoms;
        private System.Windows.Forms.TextBox txtInputDate;
        private System.Windows.Forms.Button btnSend;
    }
}