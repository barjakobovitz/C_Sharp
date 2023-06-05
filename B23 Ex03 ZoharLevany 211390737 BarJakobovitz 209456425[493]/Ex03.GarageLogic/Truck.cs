using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct Truck
    {
        private bool m_DoesItContainDengerousMaterials;
        private readonly float r_CargoTankVolume;

        internal Truck(bool i_DoesItContainDengerousMaterials, float i_Volume)
        {
            m_DoesItContainDengerousMaterials = i_DoesItContainDengerousMaterials;
            r_CargoTankVolume = i_Volume;
        }

        internal float CargoTankVolume
        {
            get
            {
                return r_CargoTankVolume;
            }

        }

        internal bool DoesItContainDengerousMaterials
        {
            get
            {
                return m_DoesItContainDengerousMaterials;
            }

            set
            {
                m_DoesItContainDengerousMaterials = value;
            }
        }
        internal string InfoAboutTruck()
        {
            return $"Does It Contain Dengerous Materials: {m_DoesItContainDengerousMaterials}\nCargo Tank Volume: {r_CargoTankVolume}";
        }
    }
}