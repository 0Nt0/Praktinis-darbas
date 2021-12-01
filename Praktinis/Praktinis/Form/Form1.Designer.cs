
namespace Praktinis
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Studentas = new System.Windows.Forms.Button();
            this.Destytojas = new System.Windows.Forms.Button();
            this.Administratorius = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(100)))), ((int)(((byte)(215)))));
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(480, 86);
            this.label2.TabIndex = 3;
            this.label2.Text = " ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(100)))), ((int)(((byte)(215)))));
            this.label1.Font = new System.Drawing.Font("NewsGoth BT", 20F);
            this.label1.Location = new System.Drawing.Point(58, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pasirinkite kas jūs esate";
            // 
            // Studentas
            // 
            this.Studentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Studentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Studentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Studentas.Location = new System.Drawing.Point(21, 119);
            this.Studentas.Name = "Studentas";
            this.Studentas.Size = new System.Drawing.Size(153, 60);
            this.Studentas.TabIndex = 5;
            this.Studentas.Text = "Studentas";
            this.Studentas.UseVisualStyleBackColor = true;
            this.Studentas.Click += new System.EventHandler(this.button1_Click);
            // 
            // Destytojas
            // 
            this.Destytojas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Destytojas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Destytojas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Destytojas.Location = new System.Drawing.Point(313, 119);
            this.Destytojas.Name = "Destytojas";
            this.Destytojas.Size = new System.Drawing.Size(153, 60);
            this.Destytojas.TabIndex = 6;
            this.Destytojas.Text = "Dėstytojas";
            this.Destytojas.UseVisualStyleBackColor = true;
            this.Destytojas.Click += new System.EventHandler(this.button2_Click);
            // 
            // Administratorius
            // 
            this.Administratorius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Administratorius.AutoSize = true;
            this.Administratorius.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Administratorius.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.Administratorius.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Administratorius.Location = new System.Drawing.Point(331, 195);
            this.Administratorius.Name = "Administratorius";
            this.Administratorius.Size = new System.Drawing.Size(114, 18);
            this.Administratorius.TabIndex = 7;
            this.Administratorius.Text = "Administratorius";
            this.Administratorius.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(203)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(478, 234);
            this.Controls.Add(this.Administratorius);
            this.Controls.Add(this.Destytojas);
            this.Controls.Add(this.Studentas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Akademinė sistema";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Studentas;
        private System.Windows.Forms.Button Destytojas;
        private System.Windows.Forms.Label Administratorius;
    }
}

