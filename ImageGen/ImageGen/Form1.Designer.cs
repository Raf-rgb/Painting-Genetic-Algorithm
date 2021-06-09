
namespace ImageGen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bestPictureBox = new System.Windows.Forms.PictureBox();
            this.originalImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bestPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bestPictureBox
            // 
            this.bestPictureBox.Location = new System.Drawing.Point(0, 0);
            this.bestPictureBox.Name = "bestPictureBox";
            this.bestPictureBox.Size = new System.Drawing.Size(200, 200);
            this.bestPictureBox.TabIndex = 0;
            this.bestPictureBox.TabStop = false;
            // 
            // originalImage
            // 
            this.originalImage.Location = new System.Drawing.Point(200, 0);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(200, 200);
            this.originalImage.TabIndex = 1;
            this.originalImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.originalImage);
            this.Controls.Add(this.bestPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bestPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bestPictureBox;
        private System.Windows.Forms.PictureBox originalImage;
    }
}

