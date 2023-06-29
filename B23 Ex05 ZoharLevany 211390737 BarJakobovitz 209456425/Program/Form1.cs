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
        int boardSize;



        public Form1(int i_Size,string i_Player1Name,string i_Player2Name,int i_Player1Score, int i_Player2Score, bool i_IsTheGameAgainstComputer) :base()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            boardSize = i_Size;
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
            Player1Details.Name = "Player1Details";
            Player1Details.Location = new System.Drawing.Point((ClientSize.Width - Player1Details.Width) / 2 , ButtonHeight * i_Size + (ButtonHeight/10) * (i_Size + 1));
            Player1Details.AutoSize = true;
            Player1Details.Text = $"{i_Player1Name}: {i_Player1Score}";
            Player1Details.Font = new Font(Player1Details.Font, FontStyle.Bold);
            Controls.Add(Player1Details);
            Label Player2Details=new Label();
            Player2Details.Name = "Player2Details";
            Player2Details.Location = new System.Drawing.Point((ClientSize.Width) / 2, ButtonHeight * i_Size + (ButtonHeight/10) * (i_Size + 1));
            Player2Details.AutoSize = true;
            Player2Details.Text = $"{i_Player2Name}: {i_Player2Score}";
            Controls.Add(Player2Details);
            game = new Game(i_Size, i_IsTheGameAgainstComputer, i_Player1Name, i_Player2Name,this);


        }

        private void Button_Click(object sender, EventArgs e)
        {
            string WinnerName;
            ButtonForMatrix button = (ButtonForMatrix)sender;
            if (IsPlayer1Play || IsTheGameAgainstComputer)
            {
                button.Text = "X";
                Controls["Player1Details"].Font = DefaultFont;
                Controls["Player2Details"].Font = new Font(Controls["Player2Details"].Font, FontStyle.Bold);
            }
            else
            {
                button.Text = "O";
                Controls["Player2Details"].Font = DefaultFont;
                Controls["Player1Details"].Font = new Font(Controls["Player1Details"].Font, FontStyle.Bold);

            }
            IsPlayer1Play = !IsPlayer1Play;
            button.Enabled = false;
            game.PlayRound(button.Row,button.Col);
            if (IsTheGameAgainstComputer)
            {
                AutoPlay(game.autoPlayer());
            }
            WinnerName = game.CheckingIfThereIsAWinner(button.Row, button.Col);
            if (WinnerName!="")
            {
                AnnounceWinner(WinnerName);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void AutoPlay(int[] spotInTheBoard)
        {
            Controls[spotInTheBoard[0]*boardSize+spotInTheBoard[1]].Text ="O";
            Controls[spotInTheBoard[0] * boardSize + spotInTheBoard[1]].Enabled = false;
            Controls["Player2Details"].Font = DefaultFont;
            Controls["Player1Details"].Font = new Font(Controls["Player1Details"].Font, FontStyle.Bold);
        }


        internal void AnnounceWinner(string i_WinnerName)
        {
            StringBuilder text=new StringBuilder();
            string WindowName;

            if (i_WinnerName == "Tie")
            {
                WindowName = "A Tie!";
                text.AppendLine("Tie!");
            }
            else
            {
                WindowName = "A Win!";
                text.AppendLine($"The winner is { i_WinnerName }!");
            }
            text.AppendLine("Would you like to play another round?");
            DialogResult result = MessageBox.Show(text.ToString(),WindowName, MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
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
            Controls["Player1Details"].Text = $"{game.FirstPlayer.Name}: {game.FirstPlayer.Score}";
            Controls["Player2Details"].Text = $"{game.SecondPlayer.Name}: {game.SecondPlayer.Score}";
            foreach (Control control in Controls)
            {
                if (control is ButtonForMatrix buttonForMetrix)
                {
                    buttonForMetrix.Text = string.Empty;
                    buttonForMetrix.Enabled = true;
                }
            }
            game.playAgain();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
