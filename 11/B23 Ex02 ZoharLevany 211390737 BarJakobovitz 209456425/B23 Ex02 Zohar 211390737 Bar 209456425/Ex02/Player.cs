using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Player
    {
        private int m_Score;
        private eGameSign m_PlayerSign;

        internal Player(eGameSign i_sign)
        {
            m_Score = 0;
            m_PlayerSign = i_sign;
        }
        internal int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        internal eGameSign Sign
        {
            get { return m_PlayerSign; }
        }
    }
}
