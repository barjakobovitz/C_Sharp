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

        internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentAirPressure;
            MaxAirPressure = i_MaxAirPressure;
        }
        internal void InflateAction(float i_AirToAdd)
        {
          if (i_AirToAdd+CurrentAirPressure<MaxAirPressure)
            {
                CurrentAirPressure += i_AirToAdd;
            }
        }

    }
}
