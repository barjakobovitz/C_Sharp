using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct Motorcycle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume;

        internal Motorcycle(eLicenseType i_LicenseType, int i_Volume)
        {
            r_LicenseType = i_LicenseType;
            r_EngineVolume = i_Volume;
        }
        internal string InfoAboutMotorcycle()
        {
            return $"License Type: {r_LicenseType}\nEngine Volume: {r_EngineVolume}";
        }
    }
}