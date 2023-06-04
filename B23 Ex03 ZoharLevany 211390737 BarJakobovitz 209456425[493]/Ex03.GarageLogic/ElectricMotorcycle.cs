using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private readonly Motorcycle r_Motorcycle;

        internal ElectricMotorcycle(string i_ModeName, string i_LicenseNumber, float i_RemainingTimeOfEngineOperation, eLicenseType i_LicenseType, int i_EngainVolume, string[] i_ManufacturersOfWheelsName, float[] i_CurrentAirPressureOfTheWheels) : base(i_ModeName, i_LicenseNumber, i_RemainingTimeOfEngineOperation)
        {
            r_Motorcycle = new Motorcycle(i_LicenseType, i_EngainVolume);
            m_MaxTimeOfEngineOperation = (float)2.6;

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
            r_Motorcycle.InfoAboutMotorcycle();
        }
    }
}