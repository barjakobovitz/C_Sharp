using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        String ManufacturerName;
        float CurrentAirPressure;
        float MaxAirPressure;

        internal Wheel(string i_manufacturerName, float i_currentAirPressure, float i_maxAirPressure)
        {
            ManufacturerName = i_manufacturerName;
            CurrentAirPressure = i_currentAirPressure;
            MaxAirPressure = i_maxAirPressure;
        }
        internal void InflateAction(float i_airToAdd)
        {
          if (i_airToAdd+CurrentAirPressure<MaxAirPressure)
            {
                CurrentAirPressure += i_airToAdd;
            }
        }

    }
}
