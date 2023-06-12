using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{

     public class  m_MainMenu

    {
        MenuItem m_mainManu;

        public m_MainMenu(string i_Headline)
        {
            m_mainManu = new MenuItem(i_Headline);
        }

        public MenuItem mainManu
        {
            get
            {
                return m_mainManu;
            }
        }

        
        public void Show()
        {
            mainManu.Show();
        }





    }
}
