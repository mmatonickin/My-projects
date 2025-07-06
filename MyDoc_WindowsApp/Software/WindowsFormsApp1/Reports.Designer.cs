namespace MyDoc
{
    partial class Reports
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
            this.btnWriteReport = new System.Windows.Forms.Button();
            this.lblReports = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWriteReport
            // 
            this.btnWriteReport.Location = new System.Drawing.Point(353, 358);
            this.btnWriteReport.Name = "btnWriteReport";
            this.btnWriteReport.Size = new System.Drawing.Size(188, 48);
            this.btnWriteReport.TabIndex = 0;
            this.btnWriteReport.Text = "Napiši nalaz";
            this.btnWriteReport.UseVisualStyleBackColor = true;
            this.btnWriteReport.Click += new System.EventHandler(this.btnShowAppointments_Click);
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblReports.Location = new System.Drawing.Point(392, 26);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(94, 29);
            this.lblReports.TabIndex = 1;
            this.lblReports.Text = "NALAZI";
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(172, 58);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.Size = new System.Drawing.Size(554, 294);
            this.dgvReports.TabIndex = 2;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(745, 464);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 3;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.btnWriteReport);
            this.Name = "Reports";
            this.Size = new System.Drawing.Size(922, 488);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteReport;
        private System.Windows.Forms.Label lblReports;
        public System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Label lblError;
    }
}
