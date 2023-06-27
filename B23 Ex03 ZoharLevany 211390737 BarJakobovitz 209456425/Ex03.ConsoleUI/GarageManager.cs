using System;
using System.Linq;

namespace Ex03.ConsoleUI
{
    internal class GarageManager
    {
        // $G$ CSS-003 (-5) Bad readonly members variable name (should be in the form of r_PamelCase).
        private readonly GarageLogic.Garage r_Garage = new GarageLogic.Garage();

        public void StartManu()
        {
            bool doesTheUserFinishedUsingTheGarage = false;
            eManuOption manuOption;

            Console.WriteLine("Welcome, how can I help you?");
            while (!doesTheUserFinishedUsingTheGarage)
            {
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1-Insert a new vehicle into the garage");
                Console.WriteLine("2-Display a list of license numbers currently in the garage");
                Console.WriteLine("3-Change a certain vehicle’s status");
                Console.WriteLine("4-Inflate tires to maximum");
                Console.WriteLine("5-Refuel a fuel based vehicle");
                Console.WriteLine("6-Charge an electric based vehicle");
                Console.WriteLine("7-Display vehicle information");
                Console.WriteLine("8-Quit");
                Console.WriteLine("Please choose a number");
                try
                {
                    manuOption = (eManuOption)int.Parse(Console.ReadLine());
                    switch (manuOption)
                    {
                        case eManuOption.One:
                            AddVehicleToGarage();
                            break;
                        case eManuOption.Two:
                            ListOfLicenseNumbers();
                            break;
                        case eManuOption.Three:
                            UpdateVehicleStatus();
                            break;
                        case eManuOption.Four:
                            InflateTiresToMaximum();
                            break;
                        case eManuOption.Five:
                            Refueling();
                            break;
                        case eManuOption.Six:
                            Recharging();
                            break;
                        case eManuOption.Seven:
                            VehicleInformation();
                            break;
                        case eManuOption.Eight:
                            Console.WriteLine("Good bye");
                            doesTheUserFinishedUsingTheGarage = true;
                            break;
                    }
                }

                catch (Exception exception)
                {
                    Console.WriteLine("Wrong Input, Please try again\n" + exception.Message);
                }
            }
        }

        internal void AddVehicleToGarage()
        {
            GarageLogic.eRepairableCarType repairableCarType;
            GarageLogic.VehicleInGarage vehicleInGarage;
            string ownerName;
            string ownerPhoneNumber;
            string modelName;
            string licenseNumber;
            bool isTheVehicleInTheGarage;

            try
            {
                Console.WriteLine("Enter the owner name");
                ownerName = Console.ReadLine();
                Console.WriteLine("Enter the owner phone number");
                ownerPhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter the model name");
                modelName = Console.ReadLine();
                Console.WriteLine("Enter the license number");
                licenseNumber = Console.ReadLine();
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1-Electric motorcycle");
                Console.WriteLine("2-Electric car");
                Console.WriteLine("3-fuel Based motorcycle");
                Console.WriteLine("4-fuel Based car");
                Console.WriteLine("5-fuel Based truck");
                Console.WriteLine("Please choose a number");
                // $G$ SFN-003 (-5) The program does not cope properly with invalid input, what about negative numbers?
                repairableCarType = (GarageLogic.eRepairableCarType)int.Parse(Console.ReadLine());
                vehicleInGarage = GarageLogic.VehicleCreator.CreateVehicleInGrage(repairableCarType, ownerName, ownerPhoneNumber, modelName, licenseNumber);
                isTheVehicleInTheGarage = r_Garage.IsTheVehicleInTheGarage(licenseNumber);
                r_Garage.AddVehicleToGarage(licenseNumber, vehicleInGarage);
                if (!isTheVehicleInTheGarage)
                {
                    switch (repairableCarType)
                    {
                        case GarageLogic.eRepairableCarType.ElectricMotorcycle:
                            AddMotorcycleToGarage(licenseNumber);
                            ElectrictyModeSetting(licenseNumber);
                            break;
                        case GarageLogic.eRepairableCarType.ElectricCar:
                            AddCarToGarage(licenseNumber);
                            ElectrictyModeSetting(licenseNumber);
                            break;
                        case GarageLogic.eRepairableCarType.FuelBasedCar:
                            AddCarToGarage(licenseNumber);
                            FuelModeSetting(licenseNumber, GarageLogic.eFuelType.Octan95);
                            break;
                        case GarageLogic.eRepairableCarType.FuelBasedMotorcycle:
                            AddMotorcycleToGarage(licenseNumber);
                            FuelModeSetting(licenseNumber, GarageLogic.eFuelType.Octan98);
                            break;
                        case GarageLogic.eRepairableCarType.FuelBasedTrack:
                            AddTruckToGarage(licenseNumber);
                            FuelModeSetting(licenseNumber, GarageLogic.eFuelType.Soler);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("There is already a vehicle with this license number in the garage");
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine("Wrong Input, Please try again\n" + exception.Message);
            }
        }

        internal void AddMotorcycleToGarage(string i_LicenseNumber)
        {
            GarageLogic.eLicenseType licenseType;
            int engineVolume;
            try
            {

                //$G$ NTT-999 (-3) You should have used verbatim string(@)
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1-A1");
                Console.WriteLine("2-A2");
                Console.WriteLine("3-AA");
                Console.WriteLine("4-B1");
                Console.WriteLine("Please choose a number");
                // $G$ SFN-003 (-5) The program does not cope properly with invalid input, what about negative numbers?
                licenseType = (GarageLogic.eLicenseType)int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the engine volume");
                engineVolume = int.Parse(Console.ReadLine());
                r_Garage.AddMotorcycle(i_LicenseNumber, licenseType, engineVolume);
                AddWheels(i_LicenseNumber, 2);
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                AddMotorcycleToGarage(i_LicenseNumber);
            }
        }

        internal void AddCarToGarage(string i_LicenseNumber)
        {
            GarageLogic.eCarColor carColor;
            GarageLogic.eNumberOfDors numberOfDors;
            try
            {
                Console.WriteLine("Here is the options for number of doors:");
                Console.WriteLine("2");
                Console.WriteLine("3");
                Console.WriteLine("4");
                Console.WriteLine("5");
                Console.WriteLine("Please choose a number");
                numberOfDors = (GarageLogic.eNumberOfDors)int.Parse(Console.ReadLine());
                Console.WriteLine("Here is the options for a color:");
                Console.WriteLine("1-White");
                Console.WriteLine("2-Black");
                Console.WriteLine("3-Yellow");
                Console.WriteLine("4-Red");
                Console.WriteLine("Please choose a number");
                carColor = (GarageLogic.eCarColor)int.Parse(Console.ReadLine());
                r_Garage.AddCar(i_LicenseNumber, carColor, numberOfDors);
                AddWheels(i_LicenseNumber, 5);
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                AddCarToGarage(i_LicenseNumber);
            }
        }

        internal void AddTruckToGarage(string i_LicenseNumber)
        {
            bool doesItContainDengerousMaterials;
            float cargoTankVolume;

            try
            {
                Console.WriteLine("Does the truck contain dengerous materials?, enter 0 for yes and anything else for no");
                doesItContainDengerousMaterials = "0" == Console.ReadLine();
                Console.WriteLine("Please enter the Cargo Tank Volume");
                cargoTankVolume = float.Parse(Console.ReadLine());
                r_Garage.AddTruck(i_LicenseNumber, doesItContainDengerousMaterials, cargoTankVolume);
                AddWheels(i_LicenseNumber, 14);
            }
            catch (Exception exception)
            {
                // $G$ NTT-001 (-10) You should have used string.Format here.
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                AddTruckToGarage(i_LicenseNumber);
            }
        }

        internal void FuelModeSetting(string i_LicenseNumber, GarageLogic.eFuelType i_FuelType)
        {
            float amountOfFuel;

            try
            {
                Console.WriteLine("Please enter the amount of fuel");
                amountOfFuel = float.Parse(Console.ReadLine());
                r_Garage.Refueling(i_LicenseNumber, i_FuelType, amountOfFuel);
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    InflateTiresToMaximum();
                }
            }
        }

        internal void ElectrictyModeSetting(string i_LicenseNumber)
        {
            float hoursToUse;

            try
            {
                Console.WriteLine("Please enter the amount of hours to use");
                hoursToUse = float.Parse(Console.ReadLine());
                r_Garage.Recharging(i_LicenseNumber, hoursToUse * 60);
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    InflateTiresToMaximum();
                }
            }
        }

        internal void AddWheels(string i_LicenseNumber, int i_NumberOfWheels)
        {
            string[] manufacturersOfWheelsName = new string[i_NumberOfWheels];
            float[] currentAirPressureOfTheWheels = new float[i_NumberOfWheels];

            try
            {
                Console.WriteLine("Do you want to enter the same info for all the wheels?, enter 0 for yes and anything else for no");
                if (Console.ReadLine() == "0")
                {
                    Console.WriteLine("enter the manufacturer name of the wheels");
                    manufacturersOfWheelsName = Enumerable.Repeat(Console.ReadLine(), i_NumberOfWheels).ToArray();
                    Console.WriteLine("enter the current Air Pressure of the wheel");
                    currentAirPressureOfTheWheels = Enumerable.Repeat(float.Parse(Console.ReadLine()), i_NumberOfWheels).ToArray();
                }
                else
                {
                    for (int i = 0; i < i_NumberOfWheels; i++)
                    {
                        Console.WriteLine($"enter the manufacturer name of the {i + 1} wheel");
                        manufacturersOfWheelsName[i] = Console.ReadLine();
                        Console.WriteLine($"enter the current Air Pressure of the {i + 1} wheel");
                        currentAirPressureOfTheWheels[i] = float.Parse(Console.ReadLine());
                    }
                }

                r_Garage.AddWheels(i_LicenseNumber, manufacturersOfWheelsName, currentAirPressureOfTheWheels);
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                AddWheels(i_LicenseNumber, i_NumberOfWheels);
            }
        }

        internal void ListOfLicenseNumbers()
        {
            Console.WriteLine("enter 0 if you want a Specific vehicle Status list and anything else for list of all the types");
            if (Console.ReadLine() == "0")
            {
                GarageLogic.eVehicleStatus vehicleStatus;
                try
                {
                    Console.WriteLine("Here is the options for the vehicle status:");
                    Console.WriteLine("1-In Repair");
                    Console.WriteLine("2-Repaired");
                    Console.WriteLine("3-Payed For");
                    Console.WriteLine("Please choose a number");
                    vehicleStatus = (GarageLogic.eVehicleStatus)int.Parse(Console.ReadLine());
                    Console.WriteLine(r_Garage.ListOfLicenseNumberOfASpecificStatus(vehicleStatus));
                }

                catch (Exception exception)
                {
                    Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                    Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                    if (Console.ReadLine() == "0")
                    {
                        ListOfLicenseNumbers();
                    }
                }
            }
            else
            {
                Console.WriteLine(r_Garage.ListOfLicenseNumberOfAnyStatus());
            }
        }

        internal void UpdateVehicleStatus()
        {
            GarageLogic.eVehicleStatus vehicleStatus;
            string licenseNumber;

            try
            {
                Console.WriteLine("Please enter the License Number");
                licenseNumber = Console.ReadLine();
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1- In Repair");
                Console.WriteLine("2-Repaired");
                Console.WriteLine("3-Payed For");
                Console.WriteLine("Please choose a number");
                vehicleStatus = (GarageLogic.eVehicleStatus)int.Parse(Console.ReadLine());
                r_Garage.UpdateVehicleStatus(vehicleStatus, licenseNumber);
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    UpdateVehicleStatus();
                }
            }
        }

        internal void InflateTiresToMaximum()
        {
            string licenseNumber;

            try
            {
                Console.WriteLine("Enter the license number");
                licenseNumber = Console.ReadLine();
                r_Garage.InflateTiresToMaximum(licenseNumber);
            }

            catch (Exception exception)
            {
                // $G$ NTT-001 (-10) You should have used string.Format here.
                // $G$ NTT-999 (-5) You should have use: Environment.NewLine instead of "\n
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    InflateTiresToMaximum();
                }
            }
        }

        internal void Refueling()
        {
            string licenseNumber;
            GarageLogic.eFuelType fuelType;
            float amountToFill;

            try
            {
                Console.WriteLine("Please enter the License Number");
                licenseNumber = Console.ReadLine();
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1- Octan98");
                Console.WriteLine("2-Octan96");
                Console.WriteLine("3-Octan95");
                Console.WriteLine("4-Soler");
                Console.WriteLine("Please choose a Fuel Type");
                fuelType = (GarageLogic.eFuelType)int.Parse(Console.ReadLine());
                Console.WriteLine("Please choose a Amount To Fill");
                amountToFill = float.Parse(Console.ReadLine());
                r_Garage.Refueling(licenseNumber, fuelType, amountToFill);
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    Refueling();
                }
            }
        }

        internal void Recharging()
        {
            string licenseNumber;
            float minutesToCharge;

            try
            {
                Console.WriteLine("Please enter the License Number");
                licenseNumber = Console.ReadLine();
                Console.WriteLine("Please enter the Minutes To Charge");
                minutesToCharge = float.Parse(Console.ReadLine());
                r_Garage.Recharging(licenseNumber, minutesToCharge);
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    Recharging();
                }
            }
        }

        internal void VehicleInformation()
        {
            string licenseNumber;

            Console.WriteLine("Please enter the License Number");
            licenseNumber = Console.ReadLine();
            try
            {
                Console.WriteLine(r_Garage.VehicleInformation(licenseNumber));
            }

            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    VehicleInformation();
                }
            }
        }
    }
}