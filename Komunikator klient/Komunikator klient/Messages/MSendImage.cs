﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Messages
{
    [Serializable]
    class MSendImage : Message
    {
        public List<string> list;
    }
}
