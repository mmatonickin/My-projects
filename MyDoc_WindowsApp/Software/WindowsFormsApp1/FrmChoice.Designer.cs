namespace WindowsFormsApp1
{
    partial class FrmChoice
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
            this.lblChoice = new System.Windows.Forms.Label();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbPatient = new System.Windows.Forms.PictureBox();
            this.pbDoc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChoice
            // 
            this.lblChoice.AutoSize = true;
            this.lblChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblChoice.Location = new System.Drawing.Point(76, 34);
            this.lblChoice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChoice.Name = "lblChoice";
            this.lblChoice.Size = new System.Drawing.Size(168, 18);
            this.lblChoice.TabIndex = 0;
            this.lblChoice.Text = "Odabir korisničke uloge:";
            // 
            // btnPatient
            // 
            this.btnPatient.Location = new System.Drawing.Point(70, 154);
            this.btnPatient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(77, 28);
            this.btnPatient.TabIndex = 1;
            this.btnPatient.Text = "Pacijent";
            this.btnPatient.UseVisualStyleBackColor = true;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.Location = new System.Drawing.Point(173, 154);
            this.btnDoctor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(77, 28);
            this.btnDoctor.TabIndex = 2;
            this.btnDoctor.Text = "Doktor";
            this.btnDoctor.UseVisualStyleBackColor = true;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(248, 218);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 26);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Izlaz";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbPatient
            // 
            this.pbPatient.Image = global::MyDoc.Properties.Resources.hospitalisation_2302715;
            this.pbPatient.Location = new System.Drawing.Point(75, 74);
            this.pbPatient.Name = "pbPatient";
            this.pbPatient.Size = new System.Drawing.Size(68, 75);
            this.pbPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPatient.TabIndex = 4;
            this.pbPatient.TabStop = false;
            // 
            // pbDoc
            // 
            this.pbDoc.Image = global::MyDoc.Properties.Resources.doctor_921059;
            this.pbDoc.Location = new System.Drawing.Point(176, 74);
            this.pbDoc.Name = "pbDoc";
            this.pbDoc.Size = new System.Drawing.Size(68, 75);
            this.pbDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDoc.TabIndex = 5;
            this.pbDoc.TabStop = false;
            // 
            // FrmChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(335, 247);
            this.Controls.Add(this.pbDoc);
            this.Controls.Add(this.pbPatient);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDoctor);
            this.Controls.Add(this.btnPatient);
            this.Controls.Add(this.lblChoice);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmChoice";
            this.Text = "FrmChoice";
            ((System.ComponentModel.ISupportInitialize)(this.pbPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoice;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbPatient;
        private System.Windows.Forms.PictureBox pbDoc;
    }
}