namespace MyDoc
{
    partial class AppointmentView
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
            this.dgvAppointment = new System.Windows.Forms.DataGridView();
            this.lblAppointment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointment
            // 
            this.dgvAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointment.Location = new System.Drawing.Point(341, 46);
            this.dgvAppointment.Name = "dgvAppointment";
            this.dgvAppointment.Size = new System.Drawing.Size(238, 325);
            this.dgvAppointment.TabIndex = 0;
            // 
            // lblAppointment
            // 
            this.lblAppointment.AutoSize = true;
            this.lblAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAppointment.Location = new System.Drawing.Point(388, 19);
            this.lblAppointment.Name = "lblAppointment";
            this.lblAppointment.Size = new System.Drawing.Size(135, 24);
            this.lblAppointment.TabIndex = 4;
            this.lblAppointment.Text = "MOJI TERMINI";
            // 
            // AppointmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.lblAppointment);
            this.Controls.Add(this.dgvAppointment);
            this.Name = "AppointmentView";
            this.Size = new System.Drawing.Size(922, 388);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAppointment;
        public System.Windows.Forms.DataGridView dgvAppointment;
    }
}
