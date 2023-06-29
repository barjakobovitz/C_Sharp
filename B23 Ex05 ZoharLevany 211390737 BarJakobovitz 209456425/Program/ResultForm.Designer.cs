
namespace Ex05
{
    partial class ResultForm
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
            this.YesButton = new System.Windows.Forms.Button();
            this.Nobutton = new System.Windows.Forms.Button();
            this.PlayAgainlabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // YesButton
            // 
            this.YesButton.Location = new System.Drawing.Point(133, 315);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(174, 61);
            this.YesButton.TabIndex = 0;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // Nobutton
            // 
            this.Nobutton.Location = new System.Drawing.Point(359, 315);
            this.Nobutton.Name = "Nobutton";
            this.Nobutton.Size = new System.Drawing.Size(174, 61);
            this.Nobutton.TabIndex = 1;
            this.Nobutton.Text = "No";
            this.Nobutton.UseVisualStyleBackColor = true;
            this.Nobutton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // PlayAgainlabel
            // 
            this.PlayAgainlabel.AutoSize = true;
            this.PlayAgainlabel.Location = new System.Drawing.Point(42, 212);
            this.PlayAgainlabel.Name = "PlayAgainlabel";
            this.PlayAgainlabel.Size = new System.Drawing.Size(491, 32);
            this.PlayAgainlabel.TabIndex = 2;
            this.PlayAgainlabel.Text = "Would you like to play another round?";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(42, 154);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(0, 32);
            this.ResultLabel.TabIndex = 3;
            this.ResultLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.PlayAgainlabel);
            this.Controls.Add(this.Nobutton);
            this.Controls.Add(this.YesButton);
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button Nobutton;
        private System.Windows.Forms.Label PlayAgainlabel;
        private System.Windows.Forms.Label ResultLabel;
    }
}