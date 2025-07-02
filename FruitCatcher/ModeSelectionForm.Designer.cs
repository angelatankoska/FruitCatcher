namespace FruitCatcher
{
    partial class ModeSelectionForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStandard = new System.Windows.Forms.Button();
            this.btnPoison = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FruitCatcher.Properties.Resources.Screenshot_2025_06_29_184945;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 456);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnStandard
            // 
            this.btnStandard.BackColor = System.Drawing.Color.Green;
            this.btnStandard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStandard.FlatAppearance.BorderSize = 4;
            this.btnStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStandard.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStandard.Location = new System.Drawing.Point(157, 168);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(506, 75);
            this.btnStandard.TabIndex = 2;
            this.btnStandard.Text = "Standard";
            this.btnStandard.UseVisualStyleBackColor = false;
            this.btnStandard.Click += new System.EventHandler(this.btnStandard_Click);
            // 
            // btnPoison
            // 
            this.btnPoison.BackColor = System.Drawing.Color.Green;
            this.btnPoison.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPoison.FlatAppearance.BorderSize = 4;
            this.btnPoison.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoison.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoison.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPoison.Location = new System.Drawing.Point(157, 249);
            this.btnPoison.Name = "btnPoison";
            this.btnPoison.Size = new System.Drawing.Size(506, 75);
            this.btnPoison.TabIndex = 3;
            this.btnPoison.Text = "Poison";
            this.btnPoison.UseVisualStyleBackColor = false;
            this.btnPoison.Click += new System.EventHandler(this.btnPoison_Click);
            // 
            // ModeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPoison);
            this.Controls.Add(this.btnStandard);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ModeSelectionForm";
            this.Text = "Select Mode";
            this.Load += new System.EventHandler(this.ModeSelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Button btnPoison;
    }
}