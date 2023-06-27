namespace Ex03.GarageLogic
{
    internal struct Truck
    {
        private bool m_DoesItContainDengerousMaterials;
        private readonly float r_CargoTankVolume;
        public static float s_MaxAirPressure = 26;

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