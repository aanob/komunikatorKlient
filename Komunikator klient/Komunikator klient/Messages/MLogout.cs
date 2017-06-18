using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Messages
{
    [Serializable]
    class MLogout : Message
    {
        public String loggedUser;
        public Boolean flag;
    }
}
