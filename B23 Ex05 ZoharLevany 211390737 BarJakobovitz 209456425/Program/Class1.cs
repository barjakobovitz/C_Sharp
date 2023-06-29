using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    class ButtonForMatrix : Button
    {
        int row;
        int col;

        internal ButtonForMatrix(int i_Row,int i_Col):base()
        {
            row = i_Row;
            col = i_Col;
        }


        public int Row
        {
            get { return row; }  // get accessor
            set { row = value; }  // set accessor
        }

        public int Col
        {
            get { return col; }  // get accessor
            set { col = value; }  // set accessor
        }
    }
}
