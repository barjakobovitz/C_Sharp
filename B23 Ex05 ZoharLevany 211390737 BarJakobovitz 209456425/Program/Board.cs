using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal class Board
    {
        private readonly eGameSign[,] r_BoardMatrix;
        private readonly int r_BoardSize;
        private readonly List<ValueTuple<int, int>> r_EmptySpots;

        internal Board(int i_SizeOfMatrix)
        {
            r_BoardSize = i_SizeOfMatrix;
            r_BoardMatrix = new eGameSign[i_SizeOfMatrix, i_SizeOfMatrix];
            r_EmptySpots = new List<ValueTuple<int, int>>();
            for (int i = 0; i < i_SizeOfMatrix; i++)
            {
                for (int j = 0; j < i_SizeOfMatrix; j++)
                {
                    r_EmptySpots.Add(new ValueTuple<int, int>(i, j));
                }
            }
        }

        internal List<ValueTuple<int, int>> EmptySpots
        {
            get
            {
                return r_EmptySpots;
            }
        }

        internal int Size
        {
            get
            {
                return r_BoardSize;
            }
        }

        internal void InsertTheMove(eGameSign i_SignToInsert, int i_Row, int i_Column)
        {
            r_BoardMatrix[i_Row, i_Column] = i_SignToInsert;
            r_EmptySpots.Remove(new ValueTuple<int, int>(i_Row, i_Column));
        }

        internal void RemoveTheMove(int i_Row, int i_Column)
        {
            r_BoardMatrix[i_Row, i_Column] = eGameSign.Empty;
            r_EmptySpots.Add(new ValueTuple<int, int>(i_Row, i_Column));
        }

        // $G$ DSN-999 (-10) This method is too long, should be divided to several methods.
        internal string GetBoardRepresentation()
        {
            StringBuilder boardRepresentation = new StringBuilder();

            boardRepresentation.Append("  ");
            for (int j = 0; j < r_BoardSize; j++)
            {
                boardRepresentation.Append(" ");
                boardRepresentation.Append((j + 1));
                boardRepresentation.Append("  ");
            }

            boardRepresentation.Append("\n");
            for (int i = 0; i < r_BoardSize; i++)
            {
                boardRepresentation.Append((i + 1));
                for (int j = 0; j < r_BoardSize; j++)
                {
                    boardRepresentation.Append("| ");
                    if (r_BoardMatrix[i, j] != 0)
                    {
                        boardRepresentation.Append(r_BoardMatrix[i, j]);
                    }
                    else
                    {
                        boardRepresentation.Append(' ');
                    }

                    boardRepresentation.Append(' ');
                }

                boardRepresentation.Append("|");
                boardRepresentation.Append("\n ");
                for (int j = 0; j < r_BoardSize; j++)
                {
                    boardRepresentation.Append("====");
                }

                boardRepresentation.Append("=\n");
            }

            return boardRepresentation.ToString();
        }

        internal bool IsPlaceAvailable(int i_Row, int i_Column)
        {

            return (r_BoardMatrix[i_Row, i_Column] == 0);
        }


        internal void ClearBoard()
        {
            r_EmptySpots.Clear();
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    r_BoardMatrix[i, j] = 0;
                    r_EmptySpots.Add(new ValueTuple<int, int>(i, j));
                }
            }
        }

        internal bool IsTheBoardFull()
        {
            bool isSomethingEmpty = false;

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    if (r_BoardMatrix[i, j] == 0)
                    {
                        isSomethingEmpty = true;
                        break;
                    }
                }
            }

            return (!isSomethingEmpty);
        }

        internal int HowMatchInTheRow(eGameSign i_Sign, int i_RowNumber)
        {
            int counter = 0;

            for (int i = 0; i < r_BoardSize; i++)
            {
                if (r_BoardMatrix[i_RowNumber, i] == i_Sign)
                {
                    counter++;
                }
            }

            return counter;
        }

        internal int HowMatchInTheColumn(eGameSign i_Sign, int i_ColumnNumber)
        {
            int counter = 0;

            for (int i = 0; i < r_BoardSize; i++)
            {
                if (r_BoardMatrix[i, i_ColumnNumber] == i_Sign)
                {
                    counter++;
                }
            }

            return counter;
        }

        internal int HowMatchInTheDiagonal(eGameSign i_Sign, int i_DiagonalNumber)
        {
            int counter = 0;
            int j;

            for (int i = 0; i < r_BoardSize; i++)
            {
                j = i;
                if (i_DiagonalNumber == 2)
                {
                    j = r_BoardSize - 1 - i;
                }

                if (r_BoardMatrix[i, j] == i_Sign)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}