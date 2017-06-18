using Komunikator_klient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Komunikator_klient.Handlers
{
    class HLogin : IHandler
    {
        public Boolean handle(Message msg)
        {
            if(msg is MLogin)
            {
                //obsluga logowania 
                
                if (((MLogin)msg).flag == true)
                {
                    //zalogowano
                    //przejdz do okienka dalej
                    Main.setLoggedUser(((MLogin)msg).login);
                    Main.setWindow(new List());
                    Main.requestList();
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
