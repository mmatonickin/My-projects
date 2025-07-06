namespace MyDoc
{
    partial class FrmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayment));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtJMBAG = new System.Windows.Forms.TextBox();
            this.txtCVC = new System.Windows.Forms.TextBox();
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "*Ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "*Prezime:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "*Broj kartice:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "*Datum isteka:";
            // 
            // dtpExpDate
            // 
            this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpDate.Location = new System.Drawing.Point(83, 161);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpExpDate.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "*CVC/CVV:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "JMBAG:";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(83, 83);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(100, 20);
            this.txtIme.TabIndex = 1;
            // 
            // txtJMBAG
            // 
            this.txtJMBAG.Location = new System.Drawing.Point(83, 213);
            this.txtJMBAG.Name = "txtJMBAG";
            this.txtJMBAG.Size = new System.Drawing.Size(100, 20);
            this.txtJMBAG.TabIndex = 6;
            // 
            // txtCVC
            // 
            this.txtCVC.Location = new System.Drawing.Point(83, 187);
            this.txtCVC.Name = "txtCVC";
            this.txtCVC.Size = new System.Drawing.Size(100, 20);
            this.txtCVC.TabIndex = 5;
            // 
            // txtCardNum
            // 
            this.txtCardNum.Location = new System.Drawing.Point(83, 135);
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(100, 20);
            this.txtCardNum.TabIndex = 3;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(83, 109);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(100, 20);
            this.txtPrezime.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(96, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 33);
            this.label7.TabIndex = 12;
            this.label7.Text = "Plaćanje";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(221, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(83, 239);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(100, 24);
            this.btnPay.TabIndex = 7;
            this.btnPay.Text = "Plaćanje";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(241, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Odustani";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "-10%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.IndianRed;
            this.label9.Location = new System.Drawing.Point(5, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Polja označena sa * su obavezna";
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 292);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtCardNum);
            this.Controls.Add(this.txtCVC);
            this.Controls.Add(this.txtJMBAG);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpExpDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPayment";
            this.Text = "FrmPayment";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtJMBAG;
        private System.Windows.Forms.TextBox txtCVC;
        private System.Windows.Forms.TextBox txtCardNum;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}