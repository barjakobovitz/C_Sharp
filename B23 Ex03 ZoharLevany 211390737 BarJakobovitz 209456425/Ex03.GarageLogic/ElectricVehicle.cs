namespace Ex03.GarageLogic
{
    internal class ElectricVehicle : Vehicle
    {
        protected float m_MaxTimeOfEngineOperation;

        internal ElectricVehicle(string i_ModeName, string i_LicenseNumber) : base(i_ModeName, i_LicenseNumber) 
        { 
        }

        internal float RemainingTime
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }

            set
            {
                m_RemainingEnergyPercentage = value;
            }
        }

        internal void Recharging(float i_HoursToCharge)
        {
            string message;

            if ((i_HoursToCharge + m_RemainingEnergyPercentage) < m_MaxTimeOfEngineOperation)
            {
                m_RemainingEnergyPercentage += i_HoursToCharge;
            }
            else
            {
                message = $"Out of range, remaining time of engine operation: {m_RemainingEnergyPercentage}, max time of engine operation: {m_MaxTimeOfEngineOperation}";
                throw new ValueOutOfRangeException(message, m_MaxTimeOfEngineOperation, 0);
            }
        }

        public override string ToString()
        {
            string electricityInfo = $"Remaining Time Of Engine Operation: {m_RemainingEnergyPercentage}";
            return $"{base.ToString()}{electricityInfo}";
        }
    }

}