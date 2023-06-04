using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelBasedVehicle
    {
        private readonly Car r_Car;
        internal FuelCar(string i_ModeName, string i_LicenseNumber, float i_CurrentAmountOfFuel, eCarColor i_Color, eNumberOfDors i_NumberOfDors, string[] i_ManufacturersOfWheelsName, float[] i_CurrentAirPressureOfTheWheels) : base(i_ModeName, i_LicenseNumber, i_CurrentAmountOfFuel)
        {
            r_Car = new Car(i_Color, i_NumberOfDors);
            m_MaxAmountOfFuel = 46;
            m_FuelType = eFuelType.Octan95;

            for (int i = 0; i < i_ManufacturersOfWheelsName.Length; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufacturersOfWheelsName[i], i_CurrentAirPressureOfTheWheels[i], 33));
            }
        }

        internal eCarColor Color
        {
            get
            {
                return r_Car.Color;
            }
        }

        internal eNumberOfDors NumberOfDors
        {
            get
            {
                return r_Car.NumberOfDors;
            }
        }

        internal override String GetTypeOfVehicleInfo()
        {
            return r_Car.InfoAboutCar();
        }


    }
}