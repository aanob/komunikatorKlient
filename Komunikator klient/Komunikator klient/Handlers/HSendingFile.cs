using Komunikator_klient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Handlers
{
    class HSendingFile : IHandler
    {
        public Boolean handle(Message msg)
        {
            if (msg is MSendingFile)
            {
                MSendingFile m = (MSendingFile)msg;
                //obsluga

                return true;
            }
            return false;
        }
    }
}
