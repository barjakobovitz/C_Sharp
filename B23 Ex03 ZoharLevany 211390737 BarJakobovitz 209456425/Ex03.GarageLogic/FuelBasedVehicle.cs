using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class FuelBasedVehicle : Vehicle
    {

        protected eFuelType m_FuelType;
        protected float m_MaxAmountOfFuel;


        internal FuelBasedVehicle(string i_ModeName, string i_LicenseNumber) : base(i_ModeName, i_LicenseNumber) { }
  
       
        internal float CurrentAmountOfFuel
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }


            set
            {
                m_RemainingEnergyPercentage = value;
            }
        }

        internal void Refueling(float i_FuelToAdd, eFuelType i_FuelType)
        {
            string message;
            if (i_FuelType == m_FuelType)
            {
                if ((m_RemainingEnergyPercentage + i_FuelToAdd) < m_MaxAmountOfFuel)
                {
                    m_RemainingEnergyPercentage += i_FuelToAdd;
                }

                else
                {
                    message = $"Out of range, current amount of fuel: {m_RemainingEnergyPercentage}, max amount of fuel: {m_MaxAmountOfFuel}";
                    throw new ValueOutOfRangeException(message, m_MaxAmountOfFuel, 0);
                }
            }
            else
            {
                message = $"Wrong fuel type, this car's fuel type is : {m_FuelType}";
                throw new ArgumentException(message);
            }
        }
        public override string ToString()
        {
            string fuelInfo = $"Current Amount Of Fuel: {m_RemainingEnergyPercentage}\nFuel Type: {m_FuelType}";
            return $"{base.ToString()}{fuelInfo}";
        }
    }
}


