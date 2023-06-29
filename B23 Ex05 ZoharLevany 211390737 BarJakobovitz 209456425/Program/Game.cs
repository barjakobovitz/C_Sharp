using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal class Game
    {
        private readonly Board r_Board;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private readonly bool r_IsTheGameAgainstComputer;
        bool isPlayerOneTurn = true;
        int[] spotInTheTable;
        eGameSign winner = eGameSign.Empty;
        string winnerName = "";


        internal Game(int i_Size, bool i_IsTheGameAgainstComputer, string i_Player1Name, string i_Player2Name, Form1 i_Form)
        {
            r_Board = new Board(i_Size);
            m_FirstPlayer = new Player(eGameSign.X, i_Player1Name);
            m_SecondPlayer = new Player(eGameSign.O, i_Player2Name);
            r_IsTheGameAgainstComputer = i_IsTheGameAgainstComputer;
        }

        /*
        internal void PlayGame()
        {

       
            while (doYouWantToPlayAgain)
            {
                
                while ((!r_Board.IsTheBoardFull()) && (winner == eGameSign.Empty))
                {
                    if ((!isPlayerOneTurn) && r_IsTheGameAgainstComputer)
                    {
                        spotInTheTable = autoPlayer();
                        isPlayerOneTurn = !isPlayerOneTurn;
                    }
                    else
                    {
                        while (true)
                        {
                            spotInTheTable = GameMannager.GetAMoveFromUser(r_Board.Size);
                            
                            if (isPlayerOneTurn)
                                {
                                    r_Board.InsertTheMove(eGameSign.X, spotInTheTable[0], spotInTheTable[1]);
                                }
                            else
                                {
                                    r_Board.InsertTheMove(eGameSign.O, spotInTheTable[0], spotInTheTable[1]);
                                }

                            break;
                            
                        }

                        isPlayerOneTurn = !isPlayerOneTurn;
                    }

                    if (!didSomeoneQuite)
                    {
                        winner = whoIsTheWinner(r_Board, spotInTheTable[0], spotInTheTable[1]);
                    }
                }

                if (winner == eGameSign.X)
                {
                    m_FirstPlayer.Score++;
                }
                else if (winner == eGameSign.O)
                {
                    m_SecondPlayer.Score++;
                }

                

            }
        }

        */


        internal void playAgain()
        {
            r_Board.ClearBoard();
            if (winner == eGameSign.X)
            {
                isPlayerOneTurn = true;
            }
            else
            {
                isPlayerOneTurn = false;
            }

            winner = eGameSign.Empty;
            winnerName = "";
        }

        internal string CheckingIfThereIsAWinner(int i_Row, int i_Col)
        {
            winner = whoIsTheWinner(r_Board, i_Row, i_Col);
            if (winner == eGameSign.X)
            {
                m_FirstPlayer.Score++;
                winnerName= m_FirstPlayer.Name;
            }
            else if (winner == eGameSign.O)
            {
                m_SecondPlayer.Score++;
                winnerName=m_SecondPlayer.Name;
            }
            else if (r_Board.IsTheBoardFull())
            {
                winnerName = "Tie";
            }
            return winnerName;
        }

        internal void PlayRound(int i_Row, int i_Col)
        {
                if (isPlayerOneTurn)
                {
                    r_Board.InsertTheMove(eGameSign.X,i_Row,i_Col);
                }
                else
                {
                    r_Board.InsertTheMove(eGameSign.O, i_Row, i_Col);

                }
        }




        private eGameSign whoIsTheWinner(Board i_Board, int i_LastRowPlayed, int i_LastColumnPlayed)
        {
            eGameSign winner = eGameSign.Empty;

            if ((i_Board.HowMatchInTheRow(eGameSign.X, i_LastRowPlayed) == i_Board.Size) || (i_Board.HowMatchInTheColumn(eGameSign.X, i_LastColumnPlayed) == i_Board.Size))
            {
                winner = eGameSign.O;
            }
            else if ((i_Board.HowMatchInTheRow(eGameSign.O, i_LastRowPlayed) == i_Board.Size) || (i_Board.HowMatchInTheColumn(eGameSign.O, i_LastColumnPlayed) == i_Board.Size))
            {
                winner = eGameSign.X;
            }
            else if (i_LastColumnPlayed == i_LastRowPlayed)
            {
                if (i_Board.HowMatchInTheDiagonal(eGameSign.X, 1) == i_Board.Size)
                {
                    winner = eGameSign.O;
                }
                else if (i_Board.HowMatchInTheDiagonal(eGameSign.O, 1) == i_Board.Size)
                {
                    winner = eGameSign.X;
                }
            }
            else if (((i_LastColumnPlayed + i_LastRowPlayed) - i_Board.Size) == -1)
            {
                if (i_Board.HowMatchInTheDiagonal(eGameSign.X, 2) == i_Board.Size)
                {
                    winner = eGameSign.O;
                }
                else if (i_Board.HowMatchInTheDiagonal(eGameSign.O, 2) == i_Board.Size)
                {
                    winner = eGameSign.X;
                }
            }

            return winner;
        }

        internal int[] autoPlayer()
        {
            int[] spotToReturn = new int[2];
            bool willThisMoveFailMe = true;
            Random randomSpot = new Random();
            eGameSign temp;
            List<ValueTuple<int, int>> listToCheck = new List<ValueTuple<int, int>>(r_Board.EmptySpots);
            int i;

            while ((willThisMoveFailMe) && (listToCheck.Count != 0))
            {
                i = randomSpot.Next(listToCheck.Count);
                spotToReturn[0] = listToCheck[i].Item1;
                spotToReturn[1] = listToCheck[i].Item2;
                listToCheck.Remove(listToCheck[i]);
                r_Board.InsertTheMove(eGameSign.O, spotToReturn[0], spotToReturn[1]);
                temp = whoIsTheWinner(r_Board, spotToReturn[0], spotToReturn[1]);
                if (temp == eGameSign.X)
                {
                    willThisMoveFailMe = true;
                    r_Board.RemoveTheMove(spotToReturn[0], spotToReturn[1]);
                }
                else
                {
                    willThisMoveFailMe = false;
                }
            }

            if (listToCheck.Count == 0)
            {
                r_Board.InsertTheMove(eGameSign.O, spotToReturn[0], spotToReturn[1]);
            }

            return spotToReturn;
        }
    }
}