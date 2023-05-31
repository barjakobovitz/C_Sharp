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
        private readonly eGameSign r_PlayerSign;

        internal Player(eGameSign i_sign)
        {
            m_Score = 0;
            r_PlayerSign = i_sign;
        }
        internal int Score
        {
            get 
            {
                return m_Score; 
            }
            set 
            {
                m_Score = value; 
            }
        }
        internal eGameSign Sign
        {
            get 
            { 
                return r_PlayerSign; 
            }
        }
    }
}
