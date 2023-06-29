using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;
// $G$ CSS-999 (-10) This method should be a private method - relevant for the all solution (if the methods is wrote in order to help you - most of the time we define it as private method)
// $G$ CSS-016 (-10) The main class should be called Program.

namespace Ex05
{
    public class GameMannager
    {

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

        internal static int[] GetAMoveFromUser(int o_SizeOfBoard)
        {
            int[] theUsersMove = new int[2];

            Console.WriteLine("in which row would you like to play your move?");
            theUsersMove[0] = getTheRowOrColumnNumber(o_SizeOfBoard);
            if (theUsersMove[0] == -1)
            {
                theUsersMove[1] = -1;
            }
            else
            {
                Console.WriteLine("in which column would you like to play your move?");
                theUsersMove[1] = getTheRowOrColumnNumber(o_SizeOfBoard);
            }

            return theUsersMove;
        }

        private static int getTheRowOrColumnNumber(int i_MaxValuePossible)
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