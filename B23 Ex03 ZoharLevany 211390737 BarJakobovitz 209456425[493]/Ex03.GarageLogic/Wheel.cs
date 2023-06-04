using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }
        internal void InflateAction(float i_AirToAdd)
        {
          if (i_AirToAdd+ m_CurrentAirPressure <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
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

            set
            {
                m_CurrentAirPressure = value;
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
