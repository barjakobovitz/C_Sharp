using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{ 
public delegate void ClickInvoker();

public abstract class Button
{
        
      
    protected string m_Text;

    public Button(string i_Text)
        {
            m_Text = i_Text;
        }

    public string Text
    {
        get { return m_Text; }
        set { m_Text = value; }
    }





        internal abstract void OnClicked();
}
}

