namespace MyDoc
{
    partial class ReportView
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
            this.lblReport = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnShowReports = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblReport.Location = new System.Drawing.Point(389, 21);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(125, 24);
            this.lblReport.TabIndex = 5;
            this.lblReport.Text = "MOJI NALAZI";
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(289, 60);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(325, 255);
            this.dgvReport.TabIndex = 7;
            // 
            // btnShowReports
            // 
            this.btnShowReports.Location = new System.Drawing.Point(383, 321);
            this.btnShowReports.Name = "btnShowReports";
            this.btnShowReports.Size = new System.Drawing.Size(131, 36);
            this.btnShowReports.TabIndex = 9;
            this.btnShowReports.Text = "Prikaži sve";
            this.btnShowReports.UseVisualStyleBackColor = true;
            this.btnShowReports.Click += new System.EventHandler(this.btnShowReports_Click);
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnShowReports);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.lblReport);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(922, 388);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnShowReports;
    }
}
