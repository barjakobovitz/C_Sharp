using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        private Car m_Car;
        private const float k_MaxTimeOfEngineOperationOfCar= 5.2f;
        internal ElectricCar(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber)
        {
            m_MaxTimeOfEngineOperation = k_MaxTimeOfEngineOperationOfCar;
            m_MaxAirPressure = Car.s_MaxAirPressure;

        }

        internal void AddCar(eCarColor i_Color, eNumberOfDors i_NumberOfDors)
        {
            m_Car = new Car(i_Color, i_NumberOfDors);
        }

        internal eCarColor Color
        {
            get
            {
                return m_Car.Color;
            }
        }

        internal eNumberOfDors NumberOfDors
        {
            get
            {
                return m_Car.NumberOfDors;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n{m_Car.InfoAboutCar()}";
        }

    }
}