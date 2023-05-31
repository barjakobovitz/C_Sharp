using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Ex02
{
    public class GameMannager
    {
        public static void Main()
        {
            StartAGame();
        }

        internal static void StartAGame()
        {
            int boardSize = GetBoardSizeFromUser();
            bool isTheGameAgainstComputer = getWhetherTheGameAgainstComputer();
            Game game = new Game(boardSize, isTheGameAgainstComputer);

            game.PlayGame();
        }

        private static int GetBoardSizeFromUser()
        {
            string input;
            int boardSize;

            Console.WriteLine("On which board size bitween 3 to 9 would you like to play?");
            input = Console.ReadLine();
            while ((!int.TryParse(input, out boardSize)) || (!isAValidBoardSize(boardSize)))
            {
                Console.WriteLine("illegal input, try again");
                input = Console.ReadLine();
            }
            return boardSize;
        }

        private static bool isAValidBoardSize(int i_SizeToCheck)
        {
            return ((i_SizeToCheck < 10) && (i_SizeToCheck > 2));
        }

        private static bool getWhetherTheGameAgainstComputer()
        {
            string input;
            bool isTheGameAgainstComputer;

            Console.WriteLine("press 'C' to play against the computer or enter to play with a friend");
            while (true)
            {
                input = Console.ReadLine();
                if (input.Equals(""))
                {
                    isTheGameAgainstComputer = false;
                    break;
                }
                else if (input.Equals("C"))
                {
                    isTheGameAgainstComputer = true;
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, try again");
                }
            }
            return isTheGameAgainstComputer;
        }

        internal static bool DoesThePlayerWhantAnotherRound()
        {
            bool anotherRound;
            string input;

            Console.WriteLine("press 'A' for another round or 'Q' to finish the game");
            while (true)
            {
                input = Console.ReadLine();
                if (input.Equals("Q"))
                {
                    anotherRound = false;
                    break;
                }
                else if (input.Equals("A"))
                {
                    anotherRound = true;
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, try again");
                }
            }
            return anotherRound;
        }

        internal static int[] GetAMoveFromUser(int i_SizeOfBoard)
        {
            int[] theUsersMove = new int[2];

            Console.WriteLine("in which row would you like to play your move?");
            theUsersMove[0] = GetTheRowOrColumnNumber(i_SizeOfBoard);
            if (theUsersMove[0] == -1)
            {
                theUsersMove[1] = -1;
            }
            else
            {
                Console.WriteLine("in which column would you like to play your move?");
                theUsersMove[1] = GetTheRowOrColumnNumber(i_SizeOfBoard);
            }
            return theUsersMove;
        }

        private static int GetTheRowOrColumnNumber(int i_MaxValuePossible)
        {
            int numberToReturn = 0;
            string input = Console.ReadLine();

            while ((!input.Equals("Q")) && ((!int.TryParse(input, out numberToReturn)) || (numberToReturn > i_MaxValuePossible) || (numberToReturn < 1)))
            {
                Console.WriteLine("invalid input, try again");
                input = Console.ReadLine();
            }

            if (input.Equals("Q"))
            {
                numberToReturn = -1;
            }
            else
            {
                numberToReturn--;
            }
            return numberToReturn;
        }

        internal static void AnnounceWinner(eGameSign i_TheWinner, int i_Player1Score, int i_Player2Score)
        {
            if (i_TheWinner == eGameSign.X)
            {
                Console.WriteLine("Player1 won!");
            }
            else if (i_TheWinner == eGameSign.O)
            {
                Console.WriteLine("Player2 won!");
            }
            else
            {
                Console.WriteLine("no one won this round");
            }
            Console.WriteLine(string.Format(
@"Current score:
Player1: {0} points, Player2: {1} points", i_Player1Score, i_Player2Score));
        }

        internal static void PrintBoard(Board i_BoardToPrint)
        {
            Screen.Clear();
            Console.Write(i_BoardToPrint.GetBoardRepresentation());
        }

        internal static void SpotIsTakenMessege()
        {
            Console.WriteLine("this spot is already taken, try a different one");
        }


    }
}
