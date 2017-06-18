using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Komunikator_klient
{
    class ChatWindows
    {
        private Dictionary<String, Communication> msgArchive = new Dictionary<String, Communication>();

        public void displayWindow(String User) {
            Communication display;
            if (msgArchive.ContainsKey(User)){
                display = msgArchive[User];
            }
            else
            {
                display = new Communication(User);
                msgArchive[User] = display;
            }

            display.refresh();
            display.Show();
        }
    }
}
