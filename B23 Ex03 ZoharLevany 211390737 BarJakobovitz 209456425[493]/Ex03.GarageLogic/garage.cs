﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Garage
    {
        private readonly Dictionary<string, VehicleInGarage> r_DictionryOfVehiclesInGarage = new Dictionary<string, VehicleInGarage> { };
        


        internal void AddVehicleToGarage(string i_LicenseNumber, eVehicle i_vehicle)
        {
            if (r_DictionryOfVehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                r_DictionryOfVehiclesInGarage[i_LicenseNumber].VehicleStatus = eVehicleStatus.InRepair;
            }
            else
            {
                Vehicle newVehicle;
                VehicleInGarage newVehicleInGarage;

                switch (i_vehicle)
                {
                    case eVehicle.ElectricMotorcycle:
                        newVehicle = new ElectricMotorcycle();
                        break;
                    case eVehicle.ElectricCar:
                        newVehicle = new ElectricCar();
                        break;
                    case eVehicle.FuelBasedMotorcycle:
                        newVehicle = new FuelBasedMotorcycle();
                        break;
                    case eVehicle.FuelBasedCar:
                        newVehicle = new FuelBasedCar();
                        break;
                    case eVehicle.FuelBasedTrack:
                        newVehicle = new FuelBasedTrack();
                        break;
                }

                newVehicleInGarage = new VehicleInGarage(newVehicle, i_OwnerName, i_OwnerPhoneNumber, eVehicleStatus.InRepair);
                r_DictionryOfVehiclesInGarage[i_LicenseNumber]= newVehicleInGarage;

            }
        }

        internal string ListOfLicenseNumberOfAnyStatus()
        {
            StringBuilder listOfLicenseNumberOfAnyStatus = new StringBuilder();
            foreach (eVehicleStatus vehicleStatus in Enum.GetValues(typeof(eVehicleStatus)))
            {
                listOfLicenseNumberOfAnyStatus.AppendLine(ListOfLicenseNumberOfASpecificStatus(vehicleStatus));
            }
                return listOfLicenseNumberOfAnyStatus.ToString();
        }

        internal string ListOfLicenseNumberOfASpecificStatus( eVehicleStatus i_VehicleStatus)
        {
            StringBuilder listOfLicenseNumberOfASpecificStatus = new StringBuilder();
            foreach(VehicleInGarage vehicleInGarage in r_DictionryOfVehiclesInGarage.Values)
            {
                if (vehicleInGarage.VehicleStatus== i_VehicleStatus)
                {
                    listOfLicenseNumberOfASpecificStatus.AppendLine(vehicleInGarage.Vehicle.LicenseNumber);
                }
            }
            return listOfLicenseNumberOfASpecificStatus.ToString();
        }

        internal void UpdateVehicleStatus(eVehicleStatus i_VehicleStatus, string i_LicenseNumber )
        {
            r_DictionryOfVehiclesInGarage[i_LicenseNumber].VehicleStatus = i_VehicleStatus;
        }

        internal void InflateTiresToMaximum(string i_LicenseNumber)
        {
            foreach (Wheel wheel in r_DictionryOfVehiclesInGarage[i_LicenseNumber].Vehicle.Wheels)
            {
                wheel.CurrentAirPressure = wheel.MaxAirPressure;
            }
        }

        internal void Refueling(String i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill)
        {
            if (r_DictionryOfVehiclesInGarage[i_LicenseNumber].Vehicle is FuelBasedVehicle fuelBasedVehicle)
            {
                fuelBasedVehicle.Refueling(i_AmountToFill, i_FuelType);
            }
        }

        internal void Recharging(String i_LicenseNumber, float i_MinutesToCharge)
        {
            if (r_DictionryOfVehiclesInGarage[i_LicenseNumber].Vehicle is ElectricVehicle electricVehicle)
            {
                electricVehicle.Recharging(i_MinutesToCharge);
            }
        }
        internal string VehicleInformation(string i_LicenseNumber)
        {
            return r_DictionryOfVehiclesInGarage[i_LicenseNumber].ToString();
        }

    }
}
