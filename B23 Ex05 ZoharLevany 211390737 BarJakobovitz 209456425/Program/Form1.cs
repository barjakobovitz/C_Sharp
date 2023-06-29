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
    public partial class Form1 : Form
    {
        private const int ButtonWidth = 50;
        private const int ButtonHeight = 50;
        private Game game;
        bool IsTheGameAgainstComputer;
        bool IsPlayer1Play=true;



        public Form1(int i_Size,string i_Player1Name,string i_Player2Name,int i_Player1Score, int i_Player2Score, bool i_IsTheGameAgainstComputer) :base()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            int formWidth = (i_Size) * ButtonWidth + (i_Size+4) *(ButtonWidth/10);
            int formHeight = (i_Size) * ButtonHeight + (i_Size+4)*(ButtonWidth/10)+ButtonHeight;
            Size = new Size(formWidth, formHeight);
            IsTheGameAgainstComputer = i_IsTheGameAgainstComputer;

            for (int i = 0; i < i_Size; i++)
            {
                for (int j = 0; j < i_Size; j++)
                {
                    
                    ButtonForMatrix button= new ButtonForMatrix(i,j);
                    button.Location = new System.Drawing.Point(ButtonWidth * j + (ButtonWidth/10) * (j + 1), ButtonHeight * i + (ButtonHeight/10) * (i + 1));
                    button.Size= new Size(ButtonHeight, ButtonWidth);
                    button.Click += Button_Click;
                    Controls.Add(button);
                    
                }
            }

            Label Player1Details=new Label();
            Player1Details.Location = new System.Drawing.Point(formWidth/2- ButtonWidth, ButtonHeight * i_Size + (ButtonHeight/10) * (i_Size + 1));
            Player1Details.Text = $"{i_Player1Name}: {i_Player1Score}";
            Player1Details.Size= new Size(50, 50);
            Controls.Add(Player1Details);
            Label Player2Details=new Label();
            Player2Details.Location = new System.Drawing.Point(formWidth / 2 + ButtonWidth, ButtonHeight * i_Size + (ButtonHeight/10) * (i_Size + 1));
            Player2Details.Text = $"{i_Player2Name}: {i_Player2Score}";
            Player2Details.Size = new Size(50, 50);
            Controls.Add(Player2Details);
            game = new Game(i_Size, i_IsTheGameAgainstComputer, i_Player1Name, i_Player2Name,this);


        }

        private void Button_Click(object sender, EventArgs e)
        {
            string WinnerName;
            ButtonForMatrix button = (ButtonForMatrix)sender;
            if (IsPlayer1Play)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }
            IsPlayer1Play = !IsPlayer1Play;
            button.Enabled = false;
            game.PlayRound(button.Row,button.Col);
            WinnerName = game.CheckingIfThereIsAWinner(button.Row, button.Col);
            if (WinnerName!="")
            {
                AnnounceWinner(WinnerName);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        internal void AnnounceWinner(string i_WinnerName)
        {
            ResultForm resultForm = new ResultForm(i_WinnerName);
            resultForm.ShowDialog();
            if(resultForm.m_whetherToPlayAnotherAround)
            {
                NewGame();
            }
            else
            {
                this.Close();
            }
            
        }
        internal void NewGame()
        {

            game.playAgain();

        }


    }
}
