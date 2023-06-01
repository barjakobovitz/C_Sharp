using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : xEngine
    {

        internal FuelEngine(float i_RemainingEnergy, float i_MaxEnergy) : base(i_RemainingEnergy, i_MaxEnergy)
        {
        }
        internal void Refueling(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if ((RemainingEnergy + i_FuelToAdd) < MaxEnergy)
            {
                RemainingEnergy += i_FuelToAdd;
            }
        }

    }
}
