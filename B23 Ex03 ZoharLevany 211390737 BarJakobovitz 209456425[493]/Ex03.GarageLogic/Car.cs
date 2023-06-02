using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct Car
    {
        private readonly eCarColor r_CarColor;
        private readonly eNumberOfDors r_NumberOfDors;

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
    }
}