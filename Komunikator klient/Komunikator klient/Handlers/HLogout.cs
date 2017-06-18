using Komunikator_klient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Handlers
{
    class HLogout : IHandler
    {
        public Boolean handle(Message msg)
        {
            if (msg is MLogout)
            {

                if (((MLogout)msg).flag == true)
                {
                   Main.setWindow(new Logout());

                }
                else
                {
                    System.Windows.MessageBox.Show("Nie wylogowano");
                }

                return true;
            }
            return false;
        }
    }
}
