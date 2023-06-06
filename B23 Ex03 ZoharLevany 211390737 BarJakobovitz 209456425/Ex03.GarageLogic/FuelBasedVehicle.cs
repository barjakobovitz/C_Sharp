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
        private float m_CurrentAmountOfFuel=0;
        protected float m_MaxAmountOfFuel;


        internal FuelBasedVehicle(string i_ModeName, string i_LicenseNumber) : base(i_ModeName, i_LicenseNumber) { }
  
       
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
            if (i_FuelType == m_FuelType)
            {
                if ((m_CurrentAmountOfFuel + i_FuelToAdd) < m_MaxAmountOfFuel)
                {
                    m_CurrentAmountOfFuel += i_FuelToAdd;
                }

                else
                {
                    message = $"Out of range, current amount of fuel: {m_CurrentAmountOfFuel}, max amount of fuel: {m_MaxAmountOfFuel}";
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
            string fuelInfo = $"Current Amount Of Fuel: {m_CurrentAmountOfFuel}\nFuel Type: {m_FuelType}";
            return $"{base.ToString()}{fuelInfo}";
        }
    }
}


