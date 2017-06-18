using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Messages
{
    [Serializable]
    class MRegister : Message
    {
        public String login;
        public String password;
        //public String repeatPassword;
        public Boolean flag;
    }
}
