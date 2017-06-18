using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Messages
{
    [Serializable]
    class MSendingMessage : Message
    {
        public String to;
        public String from;
        public String text;
    }
}
