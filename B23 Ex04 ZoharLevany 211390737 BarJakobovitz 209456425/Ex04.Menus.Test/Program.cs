using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {
            Events.m_MainMenu mainMenu = new Events.m_MainMenu("Main menu");
            Events.MenuItem firstSubMenu= mainMenu.mainManu.AddButtonForMenu("Show Date/Time");
            firstSubMenu.AddButtonForMethod(new Events.ClickInvoker(Test.ShowDate), "Show Date");
            firstSubMenu.AddButtonForMethod(new Events.ClickInvoker(Test.ShowTime), "Show Time");
            Events.MenuItem secondSubMenu = mainMenu.mainManu.AddButtonForMenu("Version and Capitals");
            secondSubMenu.AddButtonForMethod(new Events.ClickInvoker(Test.ShowVersion), "Show Version");
            secondSubMenu.AddButtonForMethod(new Events.ClickInvoker(Test.CountCapitals), "Count Capitals");
            mainMenu.Show();
        }
    }
}
