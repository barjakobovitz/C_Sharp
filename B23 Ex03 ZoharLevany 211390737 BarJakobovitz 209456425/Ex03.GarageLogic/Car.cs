namespace Ex03.GarageLogic
{
    internal struct Car
    {
        private readonly eCarColor r_CarColor;
        private readonly eNumberOfDors r_NumberOfDors;
        public static float s_MaxAirPressure = 33;

        internal Car(eCarColor i_CarColor, eNumberOfDors i_NumberOfDors)
        {
            r_CarColor = i_CarColor;
            r_NumberOfDors = i_NumberOfDors;
        }

        internal eCarColor Color
        {
            get
            {
                return r_CarColor;
            }
        }

        internal eNumberOfDors NumberOfDors
        {
            get
            {
                return r_NumberOfDors;
            }
        }

        internal string InfoAboutCar()
        {
            return $"Car Color: {r_CarColor}\nNumber Of Doors: {r_NumberOfDors}";
        }
    }
}