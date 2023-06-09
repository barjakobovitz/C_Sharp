﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Ex05
{
    public partial class GameSettingForm : Form
    {
        static int i = 0;
        public GameSettingForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public bool WhetherTheGameAgainstComputer
        {
            get { return !Player2CheckBox.Checked; }
        }

        public int getBoardSizeFromUser
        {
            get { return (int)ColsNumericUpDown.Value; }
        }

        public string Player1Name
        {
            get { return Player1TextBox.Text; }
        }

        public string Player2Name
        {
            get { return Player2TextBox.Text; }
        }


        private void Player2checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Player2TextBox.Enabled = Player2CheckBox.Checked;

            if (!Player2TextBox.Enabled)
            {
                Player2TextBox.Text = "[Computer]";
            }
            else
            {
                Player2TextBox.Text = string.Empty;
            }


        }

        private void PlayersLabel_Click(object sender, EventArgs e)
        {

        }

        private void Player1Label_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int boardSize = this.getBoardSizeFromUser;
            bool isTheGameAgainstComputer = this.WhetherTheGameAgainstComputer;
            string Player1Name = this.Player1Name;
            string Player2Name = this.Player2Name;
            if (Player2Name.Equals("[Computer]"))
            {
                Player2Name = "Computer";
            }
            this.Hide();
            Form1 game = new Form1(boardSize, Player1Name, Player2Name,i,0, isTheGameAgainstComputer);
            game.ShowDialog();
            this.Close();
        }

        private void Player1TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Player2TextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void ColsLabel_Click(object sender, EventArgs e)
        {

        }

        private void Rowslabel_Click(object sender, EventArgs e)
        {

        }

        private void GameSettingForm_Load(object sender, EventArgs e)
        {

        }

        private void Player1TextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ColsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RowsNumericUpDown.Value = ColsNumericUpDown.Value;
        }

        private void RowsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ColsNumericUpDown.Value = RowsNumericUpDown.Value;
        }

        private void Player2TextBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
