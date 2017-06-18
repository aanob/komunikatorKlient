using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Messages
{
    [Serializable]
    class MLogin : Message
    {
        public String login;
        public String password;
        public Boolean flag;
    }
}
