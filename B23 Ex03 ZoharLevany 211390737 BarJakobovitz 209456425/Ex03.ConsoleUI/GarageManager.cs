using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class GarageManager
    {
        readonly GarageLogic.Garage r_Garage=new GarageLogic.Garage();

        public void StartManu()
        {
            bool DoesTheUserFinishedUsingTheGarage = false;
            eManuOption ManuOption;
            


            Console.WriteLine("Welcome, how can I help you?");
            while (!DoesTheUserFinishedUsingTheGarage)
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
                        ManuOption = (eManuOption)int.Parse(Console.ReadLine());
                        switch (ManuOption)
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
                                DoesTheUserFinishedUsingTheGarage = true;
                                break;

                        }
                    } 
                catch(Exception exception)
                {
                    Console.WriteLine("Wrong Input, Please try again\n"+exception.Message);
                }

            }
           

        }

        internal void AddVehicleToGarage()
        {
            GarageLogic.eVehicle vehicle;
            GarageLogic.VehicleInGarage vehicleInGarage;
            string OwnerName;
            string OwnerPhoneNumber;
            string ModelName;
            string LicenseNumber;
            bool IsTheVehicleInTheGarage;


            try
            {
                Console.WriteLine("Enter the owner name");
                OwnerName = Console.ReadLine();
                Console.WriteLine("Enter the owner phone number");
                OwnerPhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter the model name");
                ModelName = Console.ReadLine();
                Console.WriteLine("Enter the license number");
                LicenseNumber = Console.ReadLine();
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1-Electric motorcycle");
                Console.WriteLine("2-Electric car");
                Console.WriteLine("3-fuel Based motorcycle");
                Console.WriteLine("4-fuel Based car");
                Console.WriteLine("5-fuel Based truck");
                Console.WriteLine("Please choose a number");
                vehicle = (GarageLogic.eVehicle)int.Parse(Console.ReadLine());
                vehicleInGarage = GarageLogic.VehicleCreator.CreateVehicleInGrage(vehicle, OwnerName, OwnerPhoneNumber, ModelName, LicenseNumber);
                IsTheVehicleInTheGarage = r_Garage.IsTheVehicleInTheGarage(LicenseNumber);
                r_Garage.AddVehicleToGarage(LicenseNumber, vehicleInGarage);
                if (!IsTheVehicleInTheGarage)
                {
                    switch (vehicle)
                    {
                        case GarageLogic.eVehicle.ElectricMotorcycle:
                            AddMotorcycleToGarage(LicenseNumber);
                            ElectrictyModeSetting(LicenseNumber);
                            break;
                        case GarageLogic.eVehicle.ElectricCar:
                            AddCarToGarage(LicenseNumber);
                            ElectrictyModeSetting(LicenseNumber);
                            break;
                        case GarageLogic.eVehicle.FuelBasedCar:
                            AddCarToGarage(LicenseNumber);
                            FuelModeSetting(LicenseNumber,GarageLogic.eFuelType.Octan95); 
                            break;
                        case GarageLogic.eVehicle.FuelBasedMotorcycle:
                            AddMotorcycleToGarage(LicenseNumber);
                            FuelModeSetting(LicenseNumber,GarageLogic.eFuelType.Octan98); 
                            break;
                        case GarageLogic.eVehicle.FuelBasedTrack:
                            AddTruckToGarage(LicenseNumber);
                            FuelModeSetting(LicenseNumber, GarageLogic.eFuelType.Soler);
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
            GarageLogic.eLicenseType LicenseType;
            int EngineVolume;
            try
            {
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1-A1");
                Console.WriteLine("2-A2");
                Console.WriteLine("3-AA");
                Console.WriteLine("4-B1");
                Console.WriteLine("Please choose a number");
                LicenseType = (GarageLogic.eLicenseType)int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the engine volume");
                EngineVolume = int.Parse(Console.ReadLine());
                r_Garage.AddMotorcycle(i_LicenseNumber, LicenseType, EngineVolume);
                AddWheels(i_LicenseNumber,2);

            }
            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to back to the manu");
                if (Console.ReadLine()=="0")
                {
                    AddMotorcycleToGarage(i_LicenseNumber);
                }
                
            }
        }
        internal void AddCarToGarage(string i_LicenseNumber)
        {
            GarageLogic.eCarColor CarColor;
            GarageLogic.eNumberOfDors NumberOfDors;
            try
            {
                Console.WriteLine("Here is the options for number of doors:");
                Console.WriteLine("2");
                Console.WriteLine("3");
                Console.WriteLine("4");
                Console.WriteLine("5");
                Console.WriteLine("Please choose a number");
                NumberOfDors = (GarageLogic.eNumberOfDors)int.Parse(Console.ReadLine());
                Console.WriteLine("Here is the options for a color:");
                Console.WriteLine("1-White");
                Console.WriteLine("2-Black");
                Console.WriteLine("3-Yellow");
                Console.WriteLine("4-Red");
                Console.WriteLine("Please choose a number");
                CarColor = (GarageLogic.eCarColor)int.Parse(Console.ReadLine());
                r_Garage.AddCar(i_LicenseNumber, CarColor, NumberOfDors);
                AddWheels(i_LicenseNumber,5);
            }
            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    AddCarToGarage(i_LicenseNumber);
                }
            }
        }
        internal void AddTruckToGarage(string i_LicenseNumber)
        {
            bool DoesItContainDengerousMaterials;
            float CargoTankVolume;
            try
            {
                Console.WriteLine("Does the truck contain dengerous materials?, enter 0 for yes and anything else for no");
                DoesItContainDengerousMaterials = "0" == Console.ReadLine();
                Console.WriteLine("Please enter the Cargo Tank Volume");
                CargoTankVolume = float.Parse(Console.ReadLine());
                r_Garage.AddTruck(i_LicenseNumber, DoesItContainDengerousMaterials, CargoTankVolume);
                AddWheels(i_LicenseNumber,14);
            }
            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    AddTruckToGarage(i_LicenseNumber);
                }
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
                r_Garage.Recharging(i_LicenseNumber,hoursToUse*60);
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
            string[] ManufacturersOfWheelsName=new string[i_NumberOfWheels];
            float[] CurrentAirPressureOfTheWheels=new float[i_NumberOfWheels];
            try
            {
                Console.WriteLine("Do you want to enter the same info for all the wheels?, enter 0 for yes and anything else for no");
                if (Console.ReadLine()=="0")
                {
                    Console.WriteLine("enter the manufacturer name of the wheels");
                    ManufacturersOfWheelsName = Enumerable.Repeat(Console.ReadLine(), i_NumberOfWheels).ToArray();
                    Console.WriteLine("enter the current Air Pressure of the wheel");
                    CurrentAirPressureOfTheWheels = Enumerable.Repeat(float.Parse(Console.ReadLine()), i_NumberOfWheels).ToArray();
                }
                else
                {
                    for (int i = 0; i < i_NumberOfWheels; i++)
                    {
                        Console.WriteLine($"enter the manufacturer name of the {i+1} wheel");
                        ManufacturersOfWheelsName[i]=Console.ReadLine();
                        Console.WriteLine($"enter the current Air Pressure of the {i+1} wheel");
                        CurrentAirPressureOfTheWheels[i] = float.Parse(Console.ReadLine());
                    }
                }
                r_Garage.AddWheels(i_LicenseNumber, ManufacturersOfWheelsName, CurrentAirPressureOfTheWheels);


            }
            catch (Exception exception)
            {
                Console.WriteLine("It didn't work, please try again.\nError message:" + exception.Message);
                Console.WriteLine("If you want to try again, enter 0 and anything else to go back to the manu");
                if (Console.ReadLine() == "0")
                {
                    AddWheels(i_LicenseNumber, i_NumberOfWheels);
                }
            }
        }

        internal void ListOfLicenseNumbers()
        {
            Console.WriteLine("enter 0 if you want a Specific vehicle Status list and anything else for list of all the types");
            if (Console.ReadLine()=="0")
            {
                GarageLogic.eVehicleStatus VehicleStatus;
                try
                {
                    Console.WriteLine("Here is the options for the vehicle status:");
                    Console.WriteLine("1-In Repair");
                    Console.WriteLine("2-Repaired");
                    Console.WriteLine("3-Payed For");
                    Console.WriteLine("Please choose a number");
                    VehicleStatus = (GarageLogic.eVehicleStatus)int.Parse( Console.ReadLine());
                    Console.WriteLine(r_Garage.ListOfLicenseNumberOfASpecificStatus(VehicleStatus));
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
            GarageLogic.eVehicleStatus VehicleStatus;
            string LicenseNumber;

            try
            {
                Console.WriteLine("Please enter the License Number");
                LicenseNumber = Console.ReadLine();
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1- In Repair");
                Console.WriteLine("2-Repaired");
                Console.WriteLine("3-Payed For");
                Console.WriteLine("Please choose a number");
                VehicleStatus = (GarageLogic.eVehicleStatus)int.Parse(Console.ReadLine());
                r_Garage.UpdateVehicleStatus(VehicleStatus,LicenseNumber);
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
            string LicenseNumber;
            try
            {
                Console.WriteLine("Enter the license number");
                LicenseNumber = Console.ReadLine();
                r_Garage.InflateTiresToMaximum(LicenseNumber);
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

        internal void Refueling()
        {
            string LicenseNumber;
            GarageLogic.eFuelType FuelType;
            float AmountToFill;

            try
            {
                Console.WriteLine("Please enter the License Number");
                LicenseNumber = Console.ReadLine();
                Console.WriteLine("Here is the options:");
                Console.WriteLine("1- Octan98");
                Console.WriteLine("2-Octan96");
                Console.WriteLine("3-Octan95");
                Console.WriteLine("4-Soler");
                Console.WriteLine("Please choose a Fuel Type");
                FuelType = (GarageLogic.eFuelType)int.Parse(Console.ReadLine());
                Console.WriteLine("Please choose a Amount To Fill");
                AmountToFill = float.Parse(Console.ReadLine());
                r_Garage.Refueling(LicenseNumber, FuelType, AmountToFill);
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
            string LicenseNumber;
            float MinutesToCharge;


            try
            {
                Console.WriteLine("Please enter the License Number");
                LicenseNumber = Console.ReadLine();
                Console.WriteLine("Please enter the Minutes To Charge");
                MinutesToCharge = float.Parse(Console.ReadLine());
                r_Garage.Recharging(LicenseNumber, MinutesToCharge);
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
            string LicenseNumber;

            Console.WriteLine("Please enter the License Number");
                LicenseNumber = Console.ReadLine();
                try
                {
                    Console.WriteLine(r_Garage.VehicleInformation(LicenseNumber));
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
