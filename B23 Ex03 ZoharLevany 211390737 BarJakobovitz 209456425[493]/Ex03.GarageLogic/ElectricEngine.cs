using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : xEngine
    {
        internal ElectricEngine(float i_RemainingEnergy, float i_MaxEnergy) : base(i_RemainingEnergy, i_MaxEnergy)
        {
        }
        internal void Recharge(float i_HoursToAdd)
        {
            if ((RemainingEnergy + i_HoursToAdd) < MaxEnergy)
            {
                RemainingEnergy += i_HoursToAdd;
            }
        }


    }
}
