using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        internal float m_RemainingEnergyPercentage = 0;
        protected List<Wheel> m_Wheels;
        // $G$ DSN-012 (-3) Bad code duplication.
        protected float m_MaxAirPressure;

        internal Vehicle(string i_ModeName, string i_LicenseNumber)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_ModelName = i_ModeName;
            m_Wheels = new List<Wheel>();
        }

        internal void AddWheels(string[] i_ManufacturersOfWheelsName, float[] i_CurrentAirPressureOfTheWheels)
        {
            for (int i = 0; i < i_ManufacturersOfWheelsName.Length; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufacturersOfWheelsName[i], i_CurrentAirPressureOfTheWheels[i], m_MaxAirPressure));
            }
        }

        internal string GetWheelsInfo()
        {
            StringBuilder WheelsInfo = new StringBuilder();
            foreach (Wheel wheel in m_Wheels)
            {
                WheelsInfo.AppendLine($"Wheel number {m_Wheels.IndexOf(wheel) + 1}:");
                WheelsInfo.AppendLine(wheel.ToString() + "\n");
            }
            return WheelsInfo.ToString();
        }

        internal string Model
        {
            get
            {
                return r_ModelName;
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public override string ToString()
        {
            return $"Model name: {r_ModelName}\nLicense number: {r_LicenseNumber}\nWheels info:\n{GetWheelsInfo()}";
        }
    }
}