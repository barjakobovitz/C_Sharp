using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleInGarage> r_DictionryOfVehiclesInGarage = new Dictionary<string, VehicleInGarage> { };
        private List<eRepairableCarType> m_ListOfVehiclesThatCanBeHandled = new List<eRepairableCarType>();


        public Garage()
        {
            foreach (eRepairableCarType repairableCarType in eRepairableCarType.GetValues(typeof(eRepairableCarType)))
            {
                m_ListOfVehiclesThatCanBeHandled.Append(repairableCarType);
            }
        }

        public void AddVehicleToGarage(string i_LicenseNumber, VehicleInGarage i_VehicleInGarage)
        {
            if (r_DictionryOfVehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                r_DictionryOfVehiclesInGarage[i_LicenseNumber].VehicleStatus = eVehicleStatus.InRepair;
            }
            else
            {
                r_DictionryOfVehiclesInGarage.Add(i_LicenseNumber, i_VehicleInGarage);
            }
        }

        public string ListOfLicenseNumberOfAnyStatus()
        {
            StringBuilder listOfLicenseNumberOfAnyStatus = new StringBuilder();
            foreach (eVehicleStatus vehicleStatus in Enum.GetValues(typeof(eVehicleStatus)))
            {
                listOfLicenseNumberOfAnyStatus.AppendLine(ListOfLicenseNumberOfASpecificStatus(vehicleStatus));
            }
                return listOfLicenseNumberOfAnyStatus.ToString();
        }

        public string ListOfLicenseNumberOfASpecificStatus(eVehicleStatus i_VehicleStatus)
        {
            StringBuilder listOfLicenseNumberOfASpecificStatus = new StringBuilder();
            foreach(VehicleInGarage vehicleInGarage in r_DictionryOfVehiclesInGarage.Values)
            {
                if (vehicleInGarage.VehicleStatus== i_VehicleStatus)
                {
                    listOfLicenseNumberOfASpecificStatus.AppendLine(vehicleInGarage.Vehicle.LicenseNumber+"\n");
                }
            }
            return listOfLicenseNumberOfASpecificStatus.ToString();
        }

        public void UpdateVehicleStatus(eVehicleStatus i_VehicleStatus, string i_LicenseNumber )
        {
            r_DictionryOfVehiclesInGarage[i_LicenseNumber].VehicleStatus = i_VehicleStatus;
        }

        public void InflateTiresToMaximum(string i_LicenseNumber)
        {
            foreach (Wheel wheel in r_DictionryOfVehiclesInGarage[i_LicenseNumber].Vehicle.Wheels)
            {
                wheel.InflateAction(wheel.MaxAirPressure-wheel.CurrentAirPressure);
            }
        }

        public void Refueling(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill)
        {
            if (r_DictionryOfVehiclesInGarage[i_LicenseNumber].Vehicle is FuelBasedVehicle fuelBasedVehicle)
            {
                fuelBasedVehicle.Refueling(i_AmountToFill, i_FuelType);
            }
        }

        public void Recharging(string i_LicenseNumber, float i_MinutesToCharge)
        {
            float hoursToCharge =i_MinutesToCharge/60;
            if (r_DictionryOfVehiclesInGarage[i_LicenseNumber].Vehicle is ElectricVehicle electricVehicle)
            {

                electricVehicle.Recharging(hoursToCharge);
            }
        }
        public string VehicleInformation(string i_LicenseNumber)
        {
            return r_DictionryOfVehiclesInGarage[i_LicenseNumber].ToString();
        }

        public void AddMotorcycle(string LicenseNumber, eLicenseType i_LicenseType, int i_EngainVolume)
        {
            Vehicle vehicle = r_DictionryOfVehiclesInGarage[LicenseNumber].Vehicle;
            if (vehicle is ElectricMotorcycle electricMotorcycle)
            {
                electricMotorcycle.AddMotorcycle(i_LicenseType, i_EngainVolume);
            }
            if (vehicle is FuelMotorcycle fuelMotorcycle)
            {
                fuelMotorcycle.AddMotorcycle(i_LicenseType, i_EngainVolume);
            }
        }
        public void AddCar(string LicenseNumber, eCarColor i_Color, eNumberOfDors i_NumberOfDors)
        {
            Vehicle vehicle = r_DictionryOfVehiclesInGarage[LicenseNumber].Vehicle;
            if (vehicle is ElectricCar electricCar)
            {
                electricCar.AddCar(i_Color, i_NumberOfDors);
            }
            if (vehicle is FuelCar fuelCar)
            {
                fuelCar.AddCar(i_Color, i_NumberOfDors);
            }
        }
        public void AddTruck(string LicenseNumber, bool i_DoesItContainDengerousMaterials, float i_CargoTankVolume)
        {
            Vehicle vehicle = r_DictionryOfVehiclesInGarage[LicenseNumber].Vehicle;
            FuelTruck fuelTruck = (FuelTruck)vehicle;
            fuelTruck.AddTruck(i_DoesItContainDengerousMaterials, i_CargoTankVolume);
        }

        public bool IsTheVehicleInTheGarage(string i_LicenseNumber)
        {
            return r_DictionryOfVehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public void AddWheels(string LicenseNumber, string[] i_ManufacturersOfWheelsName, float[] i_CurrentAirPressureOfTheWheels)
        {
            Vehicle vehicle = r_DictionryOfVehiclesInGarage[LicenseNumber].Vehicle;
            vehicle.AddWheels(i_ManufacturersOfWheelsName,i_CurrentAirPressureOfTheWheels);
        }

    }
}
