using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        float MaxValue;
        float MinValue;
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue) 
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(string i_Message, float i_MaxValue,float i_MinValue)
            : base(i_Message)
        {
            MaxValue= i_MaxValue;
            MinValue= i_MinValue;
        }
    }
}
