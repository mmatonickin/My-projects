namespace MyDoc
{
    partial class AppointmentRequest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblAppointmentRequest = new System.Windows.Forms.Label();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnShowRequests = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(283, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(325, 349);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblAppointmentRequest
            // 
            this.lblAppointmentRequest.AutoSize = true;
            this.lblAppointmentRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAppointmentRequest.Location = new System.Drawing.Point(339, 17);
            this.lblAppointmentRequest.Name = "lblAppointmentRequest";
            this.lblAppointmentRequest.Size = new System.Drawing.Size(207, 24);
            this.lblAppointmentRequest.TabIndex = 4;
            this.lblAppointmentRequest.Text = "ZAHTJEVI ZA TERMIN";
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Location = new System.Drawing.Point(343, 411);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(134, 30);
            this.btnAddAppointment.TabIndex = 5;
            this.btnAddAppointment.Text = "Dodijeli termin";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            // 
            // btnShowRequests
            // 
            this.btnShowRequests.Location = new System.Drawing.Point(483, 411);
            this.btnShowRequests.Name = "btnShowRequests";
            this.btnShowRequests.Size = new System.Drawing.Size(125, 30);
            this.btnShowRequests.TabIndex = 6;
            this.btnShowRequests.Text = "Prikaži sve";
            this.btnShowRequests.UseVisualStyleBackColor = true;
            // 
            // AppointmentRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnShowRequests);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.lblAppointmentRequest);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AppointmentRequest";
            this.Size = new System.Drawing.Size(922, 492);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAppointmentRequest;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnShowRequests;
    }
}
