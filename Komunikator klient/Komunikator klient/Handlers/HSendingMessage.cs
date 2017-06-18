using Komunikator_klient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Handlers
{
    class HSendingMessage : IHandler
    {
        public Boolean handle(Message msg)
        {
            if (msg is MSendingMessage)
            {
                MSendingMessage m = (MSendingMessage)msg;
                //obsluga wiadomosci
                Main.receiveMsg(m.text, m.from);
                return true;
            }
            return false;
        }
    }
}
