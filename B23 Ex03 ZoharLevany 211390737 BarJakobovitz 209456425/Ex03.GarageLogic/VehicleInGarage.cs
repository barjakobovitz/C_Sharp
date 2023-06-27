using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
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

        public override string ToString()
        {
            StringBuilder VehicleInfo = new StringBuilder();
            VehicleInfo.AppendLine($"Owner Name: {r_OwnerName}\nVehicle Status: {m_VehicleStatus}");
            VehicleInfo.AppendLine(r_Vehicle.ToString());
            return VehicleInfo.ToString();
        }
    }
}