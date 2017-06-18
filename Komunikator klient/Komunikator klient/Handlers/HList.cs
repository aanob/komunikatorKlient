using Komunikator_klient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Handlers
{
    class HList: IHandler
    {
        public Boolean handle(Message msg)
        {
            if (msg is MList)
            {
                MList message = (MList)msg;
                Main.setUserList(message.list);
                
            }
            return false;
        }
    }
}

