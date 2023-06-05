using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        private float m_RemainingTimeOfEngineOperation;
        protected readonly float r_MaxTimeOfEngineOperation;
        

        internal ElectricVehicle(string i_ModeName, string i_LicenseNumber, float i_RemainingTimeOfEngineOperation, float i_MaxTimeOfEngineOperation) : base(i_ModeName, i_LicenseNumber)
        {
            m_RemainingTimeOfEngineOperation = i_RemainingTimeOfEngineOperation;
            r_MaxTimeOfEngineOperation = i_MaxTimeOfEngineOperation;
        }

        internal float RemainingTime
        {
            get
            {
                return m_RemainingTimeOfEngineOperation;
            }

            set
            {
                m_RemainingTimeOfEngineOperation = value;
            }
        }
        internal void Recharging(float i_HoursToCharge) 
        {
            string message;
            if (i_HoursToCharge+m_RemainingEnergyPercentage<r_MaxTimeOfEngineOperation)
            {
                m_RemainingEnergyPercentage = i_HoursToCharge + m_RemainingEnergyPercentage;
            }
            else
            {
                message = $"Out of range, remaining time of engine operation: {m_RemainingTimeOfEngineOperation}, max time of engine operation: {r_MaxTimeOfEngineOperation}";
                throw new ValueOutOfRangeException(message, r_MaxTimeOfEngineOperation, 0);
            }
        }
        internal override String GetEnergyInfo()
        {
            return $"Remaining Time Of Engine Operation: {m_RemainingTimeOfEngineOperation}\n";
        }
    }
    
}