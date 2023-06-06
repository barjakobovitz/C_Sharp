using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreator

    {
        public static VehicleInGarage CreateVehicleInGrage(eRepairableCarType i_RepairableCarType, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModeName, string i_LicenseNumber)
        {

            VehicleInGarage vhicleInGarage;
            switch (i_RepairableCarType)
            {
                case eRepairableCarType.ElectricMotorcycle:
                    ElectricMotorcycle electricMotorcycle = new ElectricMotorcycle(i_ModeName, i_LicenseNumber);
                    vhicleInGarage = new VehicleInGarage(electricMotorcycle, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair);
                    break;
                case eRepairableCarType.ElectricCar:
                    ElectricCar electricCar = new ElectricCar(i_ModeName, i_LicenseNumber);
                    vhicleInGarage = new VehicleInGarage(electricCar, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair);
                    break;
                case eRepairableCarType.FuelBasedMotorcycle:
                    FuelMotorcycle fuelMotorcycle = new FuelMotorcycle(i_ModeName, i_LicenseNumber);
                    vhicleInGarage = new VehicleInGarage(fuelMotorcycle, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair);
                    break;
                case eRepairableCarType.FuelBasedCar:
                    FuelCar fuelCar = new FuelCar(i_ModeName, i_LicenseNumber);
                    vhicleInGarage = new VehicleInGarage(fuelCar, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair);
                    break;
                case eRepairableCarType.FuelBasedTrack:
                    FuelTruck fuelTruck = new FuelTruck(i_ModeName, i_LicenseNumber);
                    vhicleInGarage = new VehicleInGarage(fuelTruck, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair);
                    break;
                default:
                    Vehicle newVehicle = new Vehicle(i_ModeName, i_LicenseNumber);
                    vhicleInGarage = new VehicleInGarage(newVehicle, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair);
                    break;

            }
            return vhicleInGarage;

            
        }









    }
}
