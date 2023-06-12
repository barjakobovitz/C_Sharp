using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class Test
    {
        public static void ShowDate()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            Console.WriteLine("Current date: " + formattedDate);
        }
        public static void ShowTime()
        {
            DateTime currentTime = DateTime.Now;
            int currentHour = currentTime.Hour;
            Console.WriteLine("Current hour: " + currentHour);
        }

        public static void ShowVersion()
        {
            Console.WriteLine("App Version: 23.2.4.9805");
        }

        public static void CountCapitals()
        {
            string input;
            int NumberOfCapitals=0;
            Console.WriteLine("please enter the input:");
            input=Console.ReadLine();
            foreach (char character in input)
            {
                if (char.IsUpper(character))
                {
                    NumberOfCapitals += 1;
                }
            }

            Console.WriteLine($"Number Of Capitals: {NumberOfCapitals}");

        }

    }
}
