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
            bool isPlayerOneplay = true;
            bool doYouWantToPlayAgain = true;
            int[] spotInTheTable;
            eGameSign winner = eGameSign.empty;

            while (doYouWantToPlayAgain)
            {
                while ((!r_Board.IsTheBoardFull()) && (winner == eGameSign.empty))
                {
                    GameMannager.PrintBoard(r_Board);

                    if ((!isPlayerOneplay) && r_IsTheGameAgainstComputer)
                    {
                        AutoPlay(r_Board);
                        isPlayerOneplay = !isPlayerOneplay;
                    }
                    else
                    {
                        while (true)
                        {
                            spotInTheTable = GameMannager.GetAMoveFromUser(r_Board.Size);

                            if ((spotInTheTable[0] == -1) || (spotInTheTable[1] == -1))
                            {
                                if (isPlayerOneplay)
                                {
                                    winner = eGameSign.O;
                                }

                                else
                                {
                                    winner = eGameSign.X;
                                }
                                break;
                            }

                            if (r_Board.IsPlaceAvailable(spotInTheTable[0], spotInTheTable[1]))
                            {
                                if (isPlayerOneplay)
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

                        isPlayerOneplay = !isPlayerOneplay;

                    }

                    winner = WhoIsTheWinner(r_Board);
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
                        isPlayerOneplay = true;
                    }
                    else
                    {
                        isPlayerOneplay = false;
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
            else if ((i_LastColumnPlayed + i_LastRowPlayed - i_Board.Size) == 1)
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

        internal eGameSign WhoIsTheWinner(Board i_Board)
        {
            eGameSign winner = eGameSign.empty;

            for (int i = 0; i < i_Board.Size; i++)
            {
                foreach (eGameSign sign in eGameSign.GetValues(typeof(eGameSign)))
                {
                    if ((i_Board.HowMatchInTheColumn(sign, i) == i_Board.Size) || (i_Board.HowMatchInTheRow(sign, i) == i_Board.Size))
                    {
                        if (sign==eGameSign.X)
                        {
                            winner = eGameSign.O;
                            break;
                        }
                        else if (sign == eGameSign.O)
                        {
                            winner = eGameSign.X;
                            break;
                        }
                        
                    }
                }
            }

            if (winner == eGameSign.empty)
            {
                foreach (eGameSign sign in eGameSign.GetValues(typeof(eGameSign)))
                {
                    if (i_Board.HowMatchInTheDiagonal(sign, 1) == i_Board.Size || i_Board.HowMatchInTheDiagonal(sign, 2) == i_Board.Size) 
                    {
                   if (sign==eGameSign.X)
                        {
                            winner = eGameSign.O;
                            break;
                        }
                        else if (sign == eGameSign.O)
                        {
                            winner = eGameSign.X;
                            break;
                        }
               }    }
            }
                    

            }

            return winner;

        }


        internal void AutoPlay(Board board)

        {

            int bestScore = int.MinValue;

            Tuple<int, int> bestMove = null;

            int score = int.MinValue;





            foreach (Tuple<int, int> cell in board.EmptySpots.ToArray())

            {

                board.InsertTheMove(eGameSign.O, cell.Item1, cell.Item2);

                score = MinMax(eGameSign.O, board, 3, 0);

                if (bestScore < score)

                {
                    bestScore = score;
                    bestMove = cell;

                }

                board.RemoveTheMove(cell.Item1, cell.Item2);

            }

           
          
            r_Board.InsertTheMove(eGameSign.O, bestMove.Item1, bestMove.Item2);

        }



        public int MinMax(eGameSign sign, Board board, int maxDepth, int depth)

        {

            int bestScore = int.MinValue;
            

            int score;

            eGameSign winner = WhoIsTheWinner(board);


            if (winner != eGameSign.empty || board.EmptySpots.Count==0)

            {
                if (winner == eGameSign.X)

                {

                    bestScore = int.MinValue+1;

                }

                else if (winner == eGameSign.O)

                {

                    bestScore = int.MaxValue;

                }

                else

                {

                    bestScore = 0;

                }

            }
            else if (depth == maxDepth)

            {
                bestScore =(int)Math.Pow(board.HowMatchInTheDiagonal(eGameSign.O, 1), board.Size)-(int)Math.Pow(board.HowMatchInTheDiagonal(eGameSign.O, 2), board.Size);
                for (int i = 0; i < board.Size; i++)

                {
                    int colmun =board.HowMatchInTheColumn(eGameSign.O, i);
                    int row= board.HowMatchInTheRow(eGameSign.O, i);
                    bestScore +=(int)Math.Pow(colmun,board.Size) + (int)Math.Pow(row,board.Size);
                }

                bestScore = 1/bestScore ;

            }
            else

            {

                foreach (Tuple<int, int> cell in board.EmptySpots.ToArray())
                   
                { 

                    board.InsertTheMove(eGameSign.O, cell.Item1, cell.Item2);

                    if (sign == eGameSign.X)

                    {
                        
                        score = MinMax(eGameSign.X, board, maxDepth, depth + 1);

                    }

                    else

                    {

                        score = MinMax(eGameSign.O, board, maxDepth, depth + 1);

                    }



                    if (bestScore < score)

                    {

                        bestScore = score;


                    }
                    

                    board.RemoveTheMove(cell.Item1, cell.Item2);

                }



            }

            return bestScore;

        }

        private int[] AutoPlay(Board i_Board, int i)
        {
            return new int[1];
        }
    }
}
