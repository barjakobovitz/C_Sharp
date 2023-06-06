using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricVehicle : Vehicle
    {
        private float m_RemainingTimeOfEngineOperation = 0;
        protected float m_MaxTimeOfEngineOperation;
        

        internal ElectricVehicle(string i_ModeName, string i_LicenseNumber) : base(i_ModeName, i_LicenseNumber){}

  

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
            if ((i_HoursToCharge+ m_RemainingTimeOfEngineOperation) <m_MaxTimeOfEngineOperation)
            {
                m_RemainingTimeOfEngineOperation += i_HoursToCharge ;   
            }
            else
            {
                message = $"Out of range, remaining time of engine operation: {m_RemainingTimeOfEngineOperation}, max time of engine operation: {m_MaxTimeOfEngineOperation}";
                throw new ValueOutOfRangeException(message, m_MaxTimeOfEngineOperation, 0);
            }

        }
        public override string ToString()
        {
            string electricityInfo= $"Remaining Time Of Engine Operation: {m_RemainingTimeOfEngineOperation}";
            return $"{base.ToString()}{electricityInfo}";
        }
    }
    
}