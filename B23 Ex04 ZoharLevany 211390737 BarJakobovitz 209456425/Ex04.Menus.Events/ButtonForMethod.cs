using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    class ButtonForMethod: Button
    {
        public event ClickInvoker m_ClickInvoker;
        public ButtonForMethod(string i_Text, ClickInvoker i_ClickInvoker):base(i_Text)
        {
            m_ClickInvoker = i_ClickInvoker;
        }
        internal override void OnClicked()
        {
            // lets tell the form that I was clicked:
            if (m_ClickInvoker != null)
            {
                m_ClickInvoker.Invoke();
            }
        }
    }
}
