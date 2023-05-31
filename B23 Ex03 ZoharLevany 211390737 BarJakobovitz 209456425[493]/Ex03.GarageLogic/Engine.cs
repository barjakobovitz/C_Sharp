using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Engine
    {
        private float m_RemainingEnergy;
        private readonly float r_MaxEnergy;

        internal Engine(float i_RemainingEnergy, float i_MaxEnergy)
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
        internal void Recharge(float i_HoursToAdd)
        {
            if ((m_RemainingEnergy + i_HoursToAdd) < r_MaxEnergy)
            {
                m_RemainingEnergy += i_HoursToAdd;
            }
        }
        internal void Refueling(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if ((m_RemainingEnergy + i_FuelToAdd) < r_MaxEnergy )
            {
                m_RemainingEnergy += i_FuelToAdd;
            }
        }
    }
}
