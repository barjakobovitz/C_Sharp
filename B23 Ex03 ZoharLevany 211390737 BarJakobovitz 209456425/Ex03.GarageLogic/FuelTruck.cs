namespace Ex03.GarageLogic
{
    internal class FuelTruck : FuelBasedVehicle
    {
        private Truck m_Truck;
        private const float k_MaxAmountOfFuelOfTruck = 135;
        private const eFuelType k_FuelType = eFuelType.Soler;

        internal FuelTruck(string i_ModeName, string i_LicenseNumber) : base(i_ModeName, i_LicenseNumber)
        {
            m_MaxAmountOfFuel = k_MaxAmountOfFuelOfTruck;
            m_FuelType = k_FuelType;
            m_MaxAirPressure = Truck.s_MaxAirPressure;
        }

        internal void AddTruck(bool i_DoesItContainDengerousMaterials, float i_CargoTankVolume)
        {
            m_Truck = new Truck(i_DoesItContainDengerousMaterials, i_CargoTankVolume);
        }

        internal bool DoesItContainDengerousMaterials
        {
            get
            {
                return m_Truck.DoesItContainDengerousMaterials;
            }
        }

        internal float CargoTankVolume
        {
            get
            {
                return m_Truck.CargoTankVolume;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n{m_Truck.InfoAboutTruck()}";
        }
    }
}