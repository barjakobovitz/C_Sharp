using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    class ButtonForMenu : Button
    {
        MenuItem m_Menu;

        public ButtonForMenu(string i_Text, MenuItem i_MenuItem) : base(i_Text)
        {
            m_Menu = i_MenuItem;
        }

        internal void SetManuHeadline(string i_Headline)
        {
            m_Menu.headline = i_Headline;
        }

        public MenuItem menu
        {
            get
            {
                return m_Menu;
            }
        }


        internal override void OnClicked()
        {
            
            if (m_Menu!= null)
            {
                m_Menu.Show();
            }
        }
    }
}
