namespace MyDoc
{
    partial class ViewPatients
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
            this.lblPatients = new System.Windows.Forms.Label();
            this.dgvPatientsView = new System.Windows.Forms.DataGridView();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientsView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPatients
            // 
            this.lblPatients.AutoSize = true;
            this.lblPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPatients.Location = new System.Drawing.Point(341, 25);
            this.lblPatients.Name = "lblPatients";
            this.lblPatients.Size = new System.Drawing.Size(197, 24);
            this.lblPatients.TabIndex = 4;
            this.lblPatients.Text = "PRIKAZ PACIJENATA";
            // 
            // dgvPatientsView
            // 
            this.dgvPatientsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientsView.Location = new System.Drawing.Point(46, 67);
            this.dgvPatientsView.Name = "dgvPatientsView";
            this.dgvPatientsView.Size = new System.Drawing.Size(818, 397);
            this.dgvPatientsView.TabIndex = 5;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(767, 470);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(97, 29);
            this.btnShowAll.TabIndex = 6;
            this.btnShowAll.Text = "Prikaži sve";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(710, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(144, 20);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(633, 44);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 13);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Pretraživanje:";
            // 
            // ViewPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.dgvPatientsView);
            this.Controls.Add(this.lblPatients);
            this.Name = "ViewPatients";
            this.Size = new System.Drawing.Size(876, 522);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPatients;
        private System.Windows.Forms.Button btnShowAll;
        public System.Windows.Forms.DataGridView dgvPatientsView;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
    }
}
