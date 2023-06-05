using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelBasedVehicle
    {
        private readonly Motorcycle r_Motorcycle;
        private const float k_MaxAmountOfFuel =6.4f;
        private const eFuelType k_FuelType = eFuelType.Octan98;

        internal FuelMotorcycle(string i_ModeName, string i_LicenseNumber, float i_CurrentAmountOfFuel, eLicenseType i_LicenseType, int i_EngainVolume, string[] i_ManufacturersOfWheelsName, float[] i_CurrentAirPressureOfTheWheels) : base(i_ModeName, i_LicenseNumber, i_CurrentAmountOfFuel,k_MaxAmountOfFuel,k_FuelType)
        {
            r_Motorcycle = new Motorcycle(i_LicenseType, i_EngainVolume);
  

            for (int i = 0; i < i_ManufacturersOfWheelsName.Length; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufacturersOfWheelsName[i], i_CurrentAirPressureOfTheWheels[i], 31));
            }
        }

        internal eLicenseType LicenseType
        {
            get
            {
                return r_Motorcycle.LicenseType;
            }
        }

        internal int EngineVolume
        {
            get
            {
                return r_Motorcycle.EngineVolume;
            }
        }

        internal override String GetTypeOfVehicleInfo()
        {
            return r_Motorcycle.InfoAboutMotorcycle();
        }
    }
}