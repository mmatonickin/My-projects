namespace MyDoc
{
    partial class SetAppointment
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
            this.dgvSetAppointment = new System.Windows.Forms.DataGridView();
            this.lblSetAppointment = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSetAppointment
            // 
            this.dgvSetAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetAppointment.Location = new System.Drawing.Point(251, 40);
            this.dgvSetAppointment.Name = "dgvSetAppointment";
            this.dgvSetAppointment.Size = new System.Drawing.Size(378, 194);
            this.dgvSetAppointment.TabIndex = 0;
            // 
            // lblSetAppointment
            // 
            this.lblSetAppointment.AutoSize = true;
            this.lblSetAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSetAppointment.Location = new System.Drawing.Point(345, 13);
            this.lblSetAppointment.Name = "lblSetAppointment";
            this.lblSetAppointment.Size = new System.Drawing.Size(186, 24);
            this.lblSetAppointment.TabIndex = 5;
            this.lblSetAppointment.Text = "DODJELA TERMINA";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(386, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 33);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Dodaj termin";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // SetAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblSetAppointment);
            this.Controls.Add(this.dgvSetAppointment);
            this.Name = "SetAppointment";
            this.Size = new System.Drawing.Size(922, 388);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetAppointment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSetAppointment;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.DataGridView dgvSetAppointment;
    }
}
