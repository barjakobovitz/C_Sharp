using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class xEngine
    {
        private float m_RemainingEnergy;
        private readonly float r_MaxEnergy;

        internal xEngine(float i_RemainingEnergy, float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_RemainingEnergy = i_RemainingEnergy;
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }

        }

        public float RemainingEnergy
        {
            get
            {
                return m_RemainingEnergy;
            }
            set
            {
                m_RemainingEnergy = value;
            }

        }
    }
}
