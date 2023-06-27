namespace Ex03.GarageLogic
{
    // $G$ DSN-012 (-5) Bad code duplication.
    internal class FuelCar : FuelBasedVehicle
    {
        private Car m_Car;
        private const float k_MaxAmountOfFuelOfCar = 46;
        private const eFuelType k_FuelTypeOfCar = eFuelType.Octan95;

        internal FuelCar(string i_ModeName, string i_LicenseNumber) : base(i_ModeName, i_LicenseNumber)
        {
            m_MaxAmountOfFuel = k_MaxAmountOfFuelOfCar;
            m_FuelType = k_FuelTypeOfCar;
            m_MaxAirPressure = Car.s_MaxAirPressure;
        }

        internal void AddCar(eCarColor i_Color, eNumberOfDors i_NumberOfDors)
        {
            m_Car = new Car(i_Color, i_NumberOfDors);
        }

        internal eCarColor Color
        {
            get
            {
                return m_Car.Color;
            }
        }

        internal eNumberOfDors NumberOfDors
        {
            get
            {
                return m_Car.NumberOfDors;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n{m_Car.InfoAboutCar()}";
        }
    }
}