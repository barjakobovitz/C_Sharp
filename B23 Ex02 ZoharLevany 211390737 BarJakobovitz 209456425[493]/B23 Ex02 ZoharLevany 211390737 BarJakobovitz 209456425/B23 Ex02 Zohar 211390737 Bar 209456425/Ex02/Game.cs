using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Game
    {
        private readonly Board r_Board;
        private readonly Player r_FirstPlayer;
        private readonly Player r_SecondPlayer;
        private readonly bool r_IsTheGameAgainstComputer;

        internal Game(int i_Size,  bool i_IsTheGameAgainstComputer)
        {
            r_Board = new Board(i_Size);
            r_FirstPlayer = new Player(eGameSign.X);
            r_SecondPlayer = new Player(eGameSign.O);
            r_IsTheGameAgainstComputer = i_IsTheGameAgainstComputer;

        }

        internal void PlayGame()
        {
            bool isPlayerOneTurn = true;
            bool doYouWantToPlayAgain = true;
            int[] spotInTheTable;
            eGameSign winner = eGameSign.empty;
            bool didSomeoneQuite;

            while (doYouWantToPlayAgain)
            {
                didSomeoneQuite = false;
                while ((!r_Board.IsTheBoardFull()) && (winner == eGameSign.empty))
                {
                    GameMannager.PrintBoard(r_Board);

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

                            if ((spotInTheTable[0] == -1) || (spotInTheTable[1] == -1))
                            {
                                if (isPlayerOneTurn)
                                {
                                    winner = eGameSign.O;
                                }

                                else
                                {
                                    winner = eGameSign.X;
                                }
                                didSomeoneQuite = true;
                                break;
                            }

                            else if (r_Board.IsPlaceAvailable(spotInTheTable[0], spotInTheTable[1]))
                            {
                                if (isPlayerOneTurn)
                                {
                                    r_Board.InsertTheMove(eGameSign.X, spotInTheTable[0], spotInTheTable[1]);
                                    break;
                                }

                                else
                                {
                                    r_Board.InsertTheMove(eGameSign.O, spotInTheTable[0], spotInTheTable[1]);
                                    break;
                                }
                            }

                            else
                            {
                                GameMannager.SpotIsTakenMessege();
                            }
                        }

                        isPlayerOneTurn = !isPlayerOneTurn;

                    }

                    if (!didSomeoneQuite)
                    {
                        winner = WhoIsTheWinner(r_Board, spotInTheTable[0], spotInTheTable[1]);
                    }
                }

                if (winner == eGameSign.X)
                {
                    r_FirstPlayer.Score++;
                }

                else if (winner == eGameSign.O)
                {
                    r_SecondPlayer.Score++;
                }

                GameMannager.PrintBoard(r_Board);
                GameMannager.AnnounceWinner(winner, r_FirstPlayer.Score, r_SecondPlayer.Score);
                doYouWantToPlayAgain = GameMannager.DoesThePlayerWhantAnotherRound();
                if (doYouWantToPlayAgain)
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

                    winner = eGameSign.empty;

                }
            }
        }

        internal eGameSign WhoIsTheWinner(Board i_Board, int i_LastRowPlayed, int i_LastColumnPlayed)
        {
            eGameSign winner = eGameSign.empty;
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


        private int[] autoPlayer()
        {
            int[] spotToReturn = new int[2];
            bool willThisMoveFailMe = true;
            Random randomSpot = new Random();
            eGameSign temp;
            List<ValueTuple<int, int>> listToCheck = new List<ValueTuple<int, int>>(r_Board.EmptySpots);

            while ((willThisMoveFailMe) && (listToCheck.Count != 0))
            {
                int i = randomSpot.Next(listToCheck.Count);
                spotToReturn[0] = listToCheck[i].Item1;
                spotToReturn[1] = listToCheck[i].Item2;
                listToCheck.Remove(listToCheck[i]);
                r_Board.InsertTheMove(eGameSign.O, spotToReturn[0], spotToReturn[1]);
                temp = WhoIsTheWinner(r_Board, spotToReturn[0], spotToReturn[1]);
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
