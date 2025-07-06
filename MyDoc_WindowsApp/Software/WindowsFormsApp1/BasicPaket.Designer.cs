namespace MyDoc
{
    partial class BasicPaket
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
            this.lblBasicPackage = new System.Windows.Forms.Label();
            this.pbBasic = new System.Windows.Forms.PictureBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnConsultationBasic = new System.Windows.Forms.Button();
            this.txtBasicAvailable = new System.Windows.Forms.TextBox();
            this.txtAdvancedAvailable = new System.Windows.Forms.TextBox();
            this.btnConsultationAdvanced = new System.Windows.Forms.Button();
            this.lblAdvanced = new System.Windows.Forms.Label();
            this.txtPremiumAvailableConsl = new System.Windows.Forms.TextBox();
            this.btnConsultationPremium = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPremiumBloodExAv = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescAdvanced = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBloodExtraction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBasic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBasicPackage
            // 
            this.lblBasicPackage.AutoSize = true;
            this.lblBasicPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBasicPackage.Location = new System.Drawing.Point(71, 29);
            this.lblBasicPackage.Name = "lblBasicPackage";
            this.lblBasicPackage.Size = new System.Drawing.Size(179, 24);
            this.lblBasicPackage.TabIndex = 6;
            this.lblBasicPackage.Text = "\"Basic Health\" Paket";
            // 
            // pbBasic
            // 
            this.pbBasic.Image = global::MyDoc.Properties.Resources.health_insurance_10571117;
            this.pbBasic.Location = new System.Drawing.Point(110, 68);
            this.pbBasic.Name = "pbBasic";
            this.pbBasic.Size = new System.Drawing.Size(124, 125);
            this.pbBasic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBasic.TabIndex = 7;
            this.pbBasic.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDesc.Location = new System.Drawing.Point(72, 195);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(191, 30);
            this.lblDesc.TabIndex = 9;
            this.lblDesc.Text = "Paket uključuje dvije konzultacije \r\nsa liječnikom obiteljske medicine.\r\n";
            // 
            // btnConsultationBasic
            // 
            this.btnConsultationBasic.Location = new System.Drawing.Point(101, 246);
            this.btnConsultationBasic.Name = "btnConsultationBasic";
            this.btnConsultationBasic.Size = new System.Drawing.Size(124, 36);
            this.btnConsultationBasic.TabIndex = 10;
            this.btnConsultationBasic.Text = "Konzultacije";
            this.btnConsultationBasic.UseVisualStyleBackColor = true;
            this.btnConsultationBasic.Click += new System.EventHandler(this.btnConsultationBasic_Click);
            // 
            // txtBasicAvailable
            // 
            this.txtBasicAvailable.BackColor = System.Drawing.SystemColors.Control;
            this.txtBasicAvailable.Enabled = false;
            this.txtBasicAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasicAvailable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBasicAvailable.Location = new System.Drawing.Point(81, 288);
            this.txtBasicAvailable.Multiline = true;
            this.txtBasicAvailable.Name = "txtBasicAvailable";
            this.txtBasicAvailable.ReadOnly = true;
            this.txtBasicAvailable.Size = new System.Drawing.Size(162, 34);
            this.txtBasicAvailable.TabIndex = 12;
            this.txtBasicAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAdvancedAvailable
            // 
            this.txtAdvancedAvailable.Enabled = false;
            this.txtAdvancedAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvancedAvailable.Location = new System.Drawing.Point(373, 288);
            this.txtAdvancedAvailable.Multiline = true;
            this.txtAdvancedAvailable.Name = "txtAdvancedAvailable";
            this.txtAdvancedAvailable.ReadOnly = true;
            this.txtAdvancedAvailable.Size = new System.Drawing.Size(162, 34);
            this.txtAdvancedAvailable.TabIndex = 17;
            this.txtAdvancedAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConsultationAdvanced
            // 
            this.btnConsultationAdvanced.Location = new System.Drawing.Point(390, 246);
            this.btnConsultationAdvanced.Name = "btnConsultationAdvanced";
            this.btnConsultationAdvanced.Size = new System.Drawing.Size(124, 36);
            this.btnConsultationAdvanced.TabIndex = 16;
            this.btnConsultationAdvanced.Text = "Konzultacije";
            this.btnConsultationAdvanced.UseVisualStyleBackColor = true;
            this.btnConsultationAdvanced.Click += new System.EventHandler(this.btnConsultationAdvanced_Click);
            // 
            // lblAdvanced
            // 
            this.lblAdvanced.AutoSize = true;
            this.lblAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAdvanced.Location = new System.Drawing.Point(360, 29);
            this.lblAdvanced.Name = "lblAdvanced";
            this.lblAdvanced.Size = new System.Drawing.Size(220, 24);
            this.lblAdvanced.TabIndex = 13;
            this.lblAdvanced.Text = "\"Advanced Health\" Paket";
            // 
            // txtPremiumAvailableConsl
            // 
            this.txtPremiumAvailableConsl.Enabled = false;
            this.txtPremiumAvailableConsl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPremiumAvailableConsl.Location = new System.Drawing.Point(667, 288);
            this.txtPremiumAvailableConsl.Multiline = true;
            this.txtPremiumAvailableConsl.Name = "txtPremiumAvailableConsl";
            this.txtPremiumAvailableConsl.ReadOnly = true;
            this.txtPremiumAvailableConsl.Size = new System.Drawing.Size(206, 29);
            this.txtPremiumAvailableConsl.TabIndex = 22;
            this.txtPremiumAvailableConsl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConsultationPremium
            // 
            this.btnConsultationPremium.Location = new System.Drawing.Point(667, 246);
            this.btnConsultationPremium.Name = "btnConsultationPremium";
            this.btnConsultationPremium.Size = new System.Drawing.Size(103, 36);
            this.btnConsultationPremium.TabIndex = 21;
            this.btnConsultationPremium.Text = "Konzultacije";
            this.btnConsultationPremium.UseVisualStyleBackColor = true;
            this.btnConsultationPremium.Click += new System.EventHandler(this.btnConsultationPremium_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MyDoc.Properties.Resources.health_insurance_7095376;
            this.pictureBox2.Location = new System.Drawing.Point(717, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(124, 125);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(663, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "\"Premium Health\" Paket";
            // 
            // txtPremiumBloodExAv
            // 
            this.txtPremiumBloodExAv.Enabled = false;
            this.txtPremiumBloodExAv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPremiumBloodExAv.Location = new System.Drawing.Point(667, 323);
            this.txtPremiumBloodExAv.Multiline = true;
            this.txtPremiumBloodExAv.Name = "txtPremiumBloodExAv";
            this.txtPremiumBloodExAv.ReadOnly = true;
            this.txtPremiumBloodExAv.Size = new System.Drawing.Size(206, 30);
            this.txtPremiumBloodExAv.TabIndex = 23;
            this.txtPremiumBloodExAv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDoc.Properties.Resources.health_insurance_6188406;
            this.pictureBox1.Location = new System.Drawing.Point(402, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescAdvanced
            // 
            this.lblDescAdvanced.AutoSize = true;
            this.lblDescAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDescAdvanced.Location = new System.Drawing.Point(361, 195);
            this.lblDescAdvanced.Name = "lblDescAdvanced";
            this.lblDescAdvanced.Size = new System.Drawing.Size(191, 45);
            this.lblDescAdvanced.TabIndex = 24;
            this.lblDescAdvanced.Text = "Paket uključuje četiri konzultacije \r\nsa liječnikom obiteljske medicine.\r\n\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(664, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 45);
            this.label1.TabIndex = 25;
            this.label1.Text = "Paket uključuje sedam konzultacija\r\nsa liječnikom obiteljske medicine i \r\njedno v" +
    "ađenje krvi.";
            // 
            // btnBloodExtraction
            // 
            this.btnBloodExtraction.Location = new System.Drawing.Point(770, 246);
            this.btnBloodExtraction.Name = "btnBloodExtraction";
            this.btnBloodExtraction.Size = new System.Drawing.Size(103, 36);
            this.btnBloodExtraction.TabIndex = 26;
            this.btnBloodExtraction.Text = "Vađenje krvi";
            this.btnBloodExtraction.UseVisualStyleBackColor = true;
            this.btnBloodExtraction.Click += new System.EventHandler(this.btnBloodExtraction_Click);
            // 
            // BasicPaket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnBloodExtraction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDescAdvanced);
            this.Controls.Add(this.txtPremiumBloodExAv);
            this.Controls.Add(this.txtPremiumAvailableConsl);
            this.Controls.Add(this.btnConsultationPremium);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAdvancedAvailable);
            this.Controls.Add(this.btnConsultationAdvanced);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAdvanced);
            this.Controls.Add(this.txtBasicAvailable);
            this.Controls.Add(this.btnConsultationBasic);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.pbBasic);
            this.Controls.Add(this.lblBasicPackage);
            this.Name = "BasicPaket";
            this.Size = new System.Drawing.Size(922, 388);
            ((System.ComponentModel.ISupportInitialize)(this.pbBasic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBasicPackage;
        private System.Windows.Forms.PictureBox pbBasic;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblAdvanced;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDescAdvanced;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBasicAvailable;
        public System.Windows.Forms.TextBox txtAdvancedAvailable;
        public System.Windows.Forms.TextBox txtPremiumAvailableConsl;
        public System.Windows.Forms.TextBox txtPremiumBloodExAv;
        public System.Windows.Forms.Button btnConsultationBasic;
        public System.Windows.Forms.Button btnConsultationAdvanced;
        public System.Windows.Forms.Button btnConsultationPremium;
        public System.Windows.Forms.Button btnBloodExtraction;
    }
}
