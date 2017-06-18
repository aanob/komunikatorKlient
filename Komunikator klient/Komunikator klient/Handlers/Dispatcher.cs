using Komunikator_klient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikator_klient.Handlers
{
    class Dispatcher
    {
        private List<IHandler> handlers;

        public Dispatcher()
        {
            handlers = new List<IHandler>();
            handlers.Add(new HLogin());
            handlers.Add(new HSendingMessage());
            handlers.Add(new HList());
            handlers.Add(new HRegister());
            handlers.Add(new HLogout());
            //Uzupełniać kolejne handlery
        }

        public void processMessage(Message msg)
        {
            bool messageWasHandled = false;
            foreach (IHandler handler in handlers)
            {
                if (handler.handle(msg))
                {
                    //obsluzono widomosc
                    messageWasHandled = true;
                    break;
                }
            }

            if (!messageWasHandled)
            {
                // Do some default processing, throw error, whatever.
            }
        }
    }
}
