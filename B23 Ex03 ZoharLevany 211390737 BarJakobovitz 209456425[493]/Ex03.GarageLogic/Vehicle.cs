using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        protected float m_RemainingEnergyPercentage;
        protected List<Wheel> m_Wheels;

        internal Vehicle(string i_ModeName, string i_LicenseNumber)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_ModelName = i_ModeName;
            m_Wheels = new List<Wheel>();
        }

        internal string Model
        {
            get
            {
                return r_ModelName;
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

    }
}
