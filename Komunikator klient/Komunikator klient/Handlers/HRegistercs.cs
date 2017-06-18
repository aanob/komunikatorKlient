using Komunikator_klient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Handlers
{
    class HRegister : IHandler
    {
        public Boolean handle(Message msg)
        {
            if (msg is MRegister)
            {

                if (((MRegister)msg).flag == true)
                {
                    //zarejestrowano
                    //przejdz do okienka dalej
                    System.Windows.MessageBox.Show("Zarejestrowano");
                    Main.setWindow(new Login());

                }
                else
                {
                    System.Windows.MessageBox.Show("Błędny login lub hasło");
                }

                return true;
            }
            return false;
        }
    }
}
