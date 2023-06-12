using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        string m_Headline;
        List<Button> m_Buttons=new List<Button>{ };
        int m_numberOfButtons = 0;
        bool IsUsingTheManu=true;

        public MenuItem(string headline)
        {
            this.headline = headline;
        }

        public string headline
        {
            get
            {
                return m_Headline;
            }
            set
            {
                m_Headline = value;
            }
        }


         


        public void Show()
        {
            int NumberOfTheOption;
            while (IsUsingTheManu)
            {
                Console.WriteLine(m_Headline);
                Console.WriteLine("==============");
                foreach (Button button in m_Buttons)
                {
                    Console.WriteLine(button.Text);
                }
                Console.WriteLine($"0. exit");
                if (m_numberOfButtons > 1)
                {
                    Console.WriteLine($"Please enter your choice (1-{m_numberOfButtons} or 0 to exit):");
                }
                else if (m_numberOfButtons == 0)
                {
                    Console.WriteLine($"empty manu, press 0 to exit");
                }
                else
                {
                    Console.WriteLine($"Please enter your choice, 1 or 0:");
                }
                try
                {
                    NumberOfTheOption = int.Parse(Console.ReadLine());
                    if (NumberOfTheOption == 0)
                    {
                        IsUsingTheManu = false;
                        Ex02.ConsoleUtils.Screen.Clear();
                    }
                    else
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        m_Buttons[NumberOfTheOption-1].OnClicked();

                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine("Wrong input, please try again.\nError message: "+exception.Message);
                }

            }
        }

        public void AddButtonForMethod(ClickInvoker i_ClickInvoker,string i_Text)
        {
            m_numberOfButtons += 1;
            string headline = $"{m_numberOfButtons}. {i_Text}";
            ButtonForMethod newButton = new ButtonForMethod(headline, i_ClickInvoker);
            m_Buttons.Add(newButton);
            
        }
        public MenuItem AddButtonForMenu(string i_Text)
        {
            m_numberOfButtons += 1;
            string headline = $"{m_numberOfButtons}. {i_Text}";
            ButtonForMenu newButton = new ButtonForMenu(headline, new MenuItem(headline));
            m_Buttons.Add(newButton);
            return newButton.menu;

        }


    }



   
}
