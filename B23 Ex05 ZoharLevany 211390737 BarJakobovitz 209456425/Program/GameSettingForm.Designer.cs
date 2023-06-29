
namespace Ex05
{
    partial class GameSettingForm
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
            this.Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.Player1Label = new System.Windows.Forms.Label();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.RowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ColsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Rowslabel = new System.Windows.Forms.Label();
            this.ColsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Player2CheckBox
            // 
            this.Player2CheckBox.AutoSize = true;
            this.Player2CheckBox.Location = new System.Drawing.Point(87, 145);
            this.Player2CheckBox.Name = "Player2CheckBox";
            this.Player2CheckBox.Size = new System.Drawing.Size(158, 36);
            this.Player2CheckBox.TabIndex = 0;
            this.Player2CheckBox.Text = "Player2:";
            this.Player2CheckBox.UseVisualStyleBackColor = true;
            this.Player2CheckBox.CheckedChanged += new System.EventHandler(this.Player2checkBox_CheckedChanged);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(180, 349);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(302, 52);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(81, 90);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(120, 32);
            this.Player1Label.TabIndex = 2;
            this.Player1Label.Text = "Player1:";
            this.Player1Label.Click += new System.EventHandler(this.Player1Label_Click);
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Location = new System.Drawing.Point(32, 39);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(118, 32);
            this.PlayersLabel.TabIndex = 1;
            this.PlayersLabel.Text = "Players:";
            this.PlayersLabel.Click += new System.EventHandler(this.PlayersLabel_Click);
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.Location = new System.Drawing.Point(278, 88);
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(227, 38);
            this.Player1TextBox.TabIndex = 1;
            this.Player1TextBox.TextChanged += new System.EventHandler(this.Player1TextBox_TextChanged_1);
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.Enabled = false;
            this.Player2TextBox.Location = new System.Drawing.Point(278, 145);
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(227, 38);
            this.Player2TextBox.TabIndex = 2;
            this.Player2TextBox.Text = "[Computer]";
            this.Player2TextBox.TextChanged += new System.EventHandler(this.Player2TextBox_TextChanged_1);
            // 
            // RowsNumericUpDown
            // 
            this.RowsNumericUpDown.Location = new System.Drawing.Point(235, 247);
            this.RowsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RowsNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.RowsNumericUpDown.Name = "RowsNumericUpDown";
            this.RowsNumericUpDown.Size = new System.Drawing.Size(81, 38);
            this.RowsNumericUpDown.TabIndex = 3;
            this.RowsNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.RowsNumericUpDown.ValueChanged += new System.EventHandler(this.RowsNumericUpDown_ValueChanged);
            // 
            // ColsNumericUpDown
            // 
            this.ColsNumericUpDown.Location = new System.Drawing.Point(438, 247);
            this.ColsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ColsNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ColsNumericUpDown.Name = "ColsNumericUpDown";
            this.ColsNumericUpDown.Size = new System.Drawing.Size(82, 38);
            this.ColsNumericUpDown.TabIndex = 4;
            this.ColsNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ColsNumericUpDown.ValueChanged += new System.EventHandler(this.ColsNumericUpDown_ValueChanged);
            // 
            // Rowslabel
            // 
            this.Rowslabel.AutoSize = true;
            this.Rowslabel.Location = new System.Drawing.Point(136, 253);
            this.Rowslabel.Name = "Rowslabel";
            this.Rowslabel.Size = new System.Drawing.Size(93, 32);
            this.Rowslabel.TabIndex = 8;
            this.Rowslabel.Text = "Rows:";
            this.Rowslabel.Click += new System.EventHandler(this.Rowslabel_Click);
            // 
            // ColsLabel
            // 
            this.ColsLabel.AutoSize = true;
            this.ColsLabel.Location = new System.Drawing.Point(352, 253);
            this.ColsLabel.Name = "ColsLabel";
            this.ColsLabel.Size = new System.Drawing.Size(80, 32);
            this.ColsLabel.TabIndex = 9;
            this.ColsLabel.Text = "Cols:";
            this.ColsLabel.Click += new System.EventHandler(this.ColsLabel_Click);
            // 
            // GameSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ColsLabel);
            this.Controls.Add(this.Rowslabel);
            this.Controls.Add(this.ColsNumericUpDown);
            this.Controls.Add(this.RowsNumericUpDown);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Player2CheckBox);
            this.Name = "GameSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Setting Form";
            this.Load += new System.EventHandler(this.GameSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RowsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Player2CheckBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.TextBox Player1TextBox;
        private System.Windows.Forms.TextBox Player2TextBox;
        private System.Windows.Forms.NumericUpDown RowsNumericUpDown;
        private System.Windows.Forms.NumericUpDown ColsNumericUpDown;
        private System.Windows.Forms.Label Rowslabel;
        private System.Windows.Forms.Label ColsLabel;
    }
}