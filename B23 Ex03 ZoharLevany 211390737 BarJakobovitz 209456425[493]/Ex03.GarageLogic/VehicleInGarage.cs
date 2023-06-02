using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehicleInGarage
    {
        private readonly Vehicle r_Vehicle;
        private readonly String r_OwnerName;
        private readonly String r_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        internal VehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus)
        {
            r_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = i_VehicleStatus;
        }

 
        internal eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }

        }
        internal Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }

        }
        internal string GetVehicleInfo()
        {
            StringBuilder VehicleInfo = new StringBuilder();
            VehicleInfo.AppendLine(Vehicle.ToString());
            VehicleInfo.AppendLine($"OwnerName: {r_OwnerName}\nVehicleStatus: {m_VehicleStatus}");
            VehicleInfo.AppendLine(Vehicle.GetEnergyInfo());
            VehicleInfo.AppendLine(Vehicle.GetTypeOfVehicleInfo());
            return VehicleInfo.ToString();
        }




    }
}
