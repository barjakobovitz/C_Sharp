using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private Motorcycle m_Motorcycle;
        private const float k_MaxTimeOfEngineOperationOfMotorcycle = 2.6f;

        internal ElectricMotorcycle(string i_ModeName, string i_LicenseNumber) : base(i_ModeName, i_LicenseNumber)
        {
            m_MaxTimeOfEngineOperation = k_MaxTimeOfEngineOperationOfMotorcycle;
            m_MaxAirPressure = Motorcycle.s_MaxAirPressure;
        }

        internal void AddMotorcycle(eLicenseType i_LicenseType, int i_EngainVolume)
        {
            m_Motorcycle = new Motorcycle(i_LicenseType, i_EngainVolume);
        }

        internal eLicenseType LicenseType
        {
            get
            {
                return m_Motorcycle.LicenseType;
            }
        }

        internal int EngineVolume
        {
            get
            {
                return m_Motorcycle.EngineVolume;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n{m_Motorcycle.InfoAboutMotorcycle()}";
        }
    }
}