using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelTruck : FuelBasedVehicle
    {
        private readonly Truck r_Truck;
        private const float k_MaxAmountOfFuel = 135;
        private const eFuelType k_FuelType = eFuelType.Soler;


        internal FuelTruck(string i_ModeName, string i_LicenseNumber, float i_CurrentAmountOfFuel, bool i_DoesItContainDengerousMaterials, float i_CargoTankVolume, string[] i_ManufacturersOfWheelsName, float[] i_CurrentAirPressureOfTheWheels) : base(i_ModeName, i_LicenseNumber, i_CurrentAmountOfFuel,k_MaxAmountOfFuel,k_FuelType)
        {
            r_Truck = new Truck(i_DoesItContainDengerousMaterials, i_CargoTankVolume);
            

            for (int i = 0; i < i_ManufacturersOfWheelsName.Length; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufacturersOfWheelsName[i], i_CurrentAirPressureOfTheWheels[i], 26));
            }
        }

        internal bool DoesItContainDengerousMaterials
        {
            get
            {
                return r_Truck.DoesItContainDengerousMaterials;
            }
        }

        internal float CargoTankVolume
        {
            get
            {
                return r_Truck.CargoTankVolume;
            }
        }

        internal override String GetTypeOfVehicleInfo()
        {
            return r_Truck.InfoAboutTruck();
        }
    }
}