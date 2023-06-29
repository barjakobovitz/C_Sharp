using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal struct Player
    {
        private int m_Score;
        private eGameSign m_PlayerSign;
        private string m_Name;

        internal Player(eGameSign i_sign, string i_PlayerName)
        {
            m_Score = 0;
            m_PlayerSign = i_sign;
            m_Name = i_PlayerName;
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
        public string Name
        {
            get { return m_Name; }
        }
    }
}