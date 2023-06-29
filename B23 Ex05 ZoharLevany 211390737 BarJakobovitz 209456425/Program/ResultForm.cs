using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    public partial class ResultForm : Form
    {
        internal bool m_whetherToPlayAnotherAround=false;
        internal ResultForm(string i_WinnerName)
        {
            InitializeComponent();
            if (i_WinnerName == "Tie")
            {
                Text = "A Tie!";
                this.ResultLabel.Text = "Tie!";
            }
            else 
            {
                Text = "A Win!";
                this.ResultLabel.Text = $"The winner is {i_WinnerName}!";
            }
         
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            m_whetherToPlayAnotherAround = false;
            this.Close();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            m_whetherToPlayAnotherAround = true;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
