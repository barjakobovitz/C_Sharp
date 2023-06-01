using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class FuelBasedVehicle : Vehicle
    {
        protected readonly eFuelType r_FuelType;
        private float m_CurrentAmountOfFuel;
        protected readonly float m_MaxAmountOfFuel;

        internal FuelBasedVehicle(string i_ModeName, string i_LicenseNumber, float i_CurrentAmountOfFuel) : base(i_ModeName, i_LicenseNumber)
        {
            m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
        }

        internal float CurrentAmountOfFuel
        {
            get
            {
                return m_CurrentAmountOfFuel;
            }


            set
            {
                m_CurrentAmountOfFuel = value;
            }
        }

        internal void Refueling(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType == r_FuelType)
            {
                if ((m_CurrentAmountOfFuel + i_FuelToAdd) < m_MaxAmountOfFuel)
                {
                    m_CurrentAmountOfFuel += i_FuelToAdd;
                }
            }
        }
    }
}