namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            if (i_CurrentAirPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException($"Out of range, Current Air Pressure: {i_CurrentAirPressure}, max air pressure: {i_MaxAirPressure}", r_MaxAirPressure, 0);
            }

            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        internal void InflateAction(float i_AirToAdd)
        {
            string message;

            if ((i_AirToAdd + m_CurrentAirPressure) <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                message = $"Out of range, Current Air Pressure: {m_CurrentAirPressure}, max air pressure: {r_MaxAirPressure}";
                throw new ValueOutOfRangeException(message, r_MaxAirPressure, 0);
            }
        }

        internal string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        internal float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        internal float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public override string ToString()
        {
            return $"Current Air Pressure: {m_CurrentAirPressure}\nManufacturer Name: {r_ManufacturerName}";
        }
    }
}