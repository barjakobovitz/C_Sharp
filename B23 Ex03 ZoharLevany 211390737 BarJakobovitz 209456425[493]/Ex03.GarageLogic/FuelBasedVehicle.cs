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
        protected readonly float r_MaxAmountOfFuel;
       

        internal FuelBasedVehicle(string i_ModeName, string i_LicenseNumber, float i_CurrentAmountOfFuel, float i_MaxAmountOfFuel, eFuelType i_FuelType) : base(i_ModeName, i_LicenseNumber)
        {
            m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
            r_FuelType=i_FuelType;
            r_MaxAmountOfFuel= i_MaxAmountOfFuel;
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
            string message;
            if (i_FuelType == r_FuelType)
            {
                if ((m_CurrentAmountOfFuel + i_FuelToAdd) < r_MaxAmountOfFuel)
                {
                    m_CurrentAmountOfFuel += i_FuelToAdd;
                }

                else
                {
                    message = $"Out of range, current amount of fuel: {m_CurrentAmountOfFuel}, max amount of fuel: {r_MaxAmountOfFuel}";
                    throw new ValueOutOfRangeException(message, r_MaxAmountOfFuel, 0);
                }
            }
        }
        internal override String GetEnergyInfo()
        {
            return $"Current Amount Of Fuel: {m_CurrentAmountOfFuel}\nFuel Type: {r_FuelType}";
        }
    }
}