using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient
{
    class TempArchive
    {
        public Dictionary<String, List<MessagesFromUserArchive>> msgArchive = new Dictionary<String, List<MessagesFromUserArchive>>();

        public void save(String fromUser, String text, bool fromMe) {
            List<MessagesFromUserArchive> list;
            if (msgArchive.ContainsKey(fromUser)){
                list = msgArchive[fromUser];
            }
             else
            {
                list = new List<MessagesFromUserArchive>(); // stwórz nową liste dla 1 wiadomości
            }

            MessagesFromUserArchive row = new MessagesFromUserArchive(text, fromMe);
            list.Add(row);
            
            msgArchive[fromUser] = list;

        }

        public List<MessagesFromUserArchive> read (String fromUser) 
        {
            List<MessagesFromUserArchive> list = null;
            if (msgArchive.ContainsKey(fromUser))
            {
                list = msgArchive[fromUser];
                foreach (MessagesFromUserArchive entry in list)
                {
                    entry.isReaded = true;
                }
                // sprawdzić czy status sie zmienił czy trzeba aktualizować
            }
            return list;
        }
    }
    class MessagesFromUserArchive {
        public String text;
        public DateTime date;
        public Boolean isReaded;
        public Boolean fromMe;

        public MessagesFromUserArchive(String msg, Boolean fromMe)
        {
            text = msg;
            isReaded = false;
            date = DateTime.Now;
            this.fromMe = fromMe;
        }
    }
}
