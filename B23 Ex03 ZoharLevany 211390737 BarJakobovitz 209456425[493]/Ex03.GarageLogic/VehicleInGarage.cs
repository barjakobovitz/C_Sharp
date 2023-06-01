using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehicleInGarage
    {
        private readonly Vehicle r_vehicle;
        private readonly String r_OwnerName;
        private readonly String r_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public VehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus)
        {
            r_vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = i_VehicleStatus;
        }
    }
}
