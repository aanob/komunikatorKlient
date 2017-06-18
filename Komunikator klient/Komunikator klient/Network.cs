using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Komunikator_klient.Messages;
using Komunikator_klient.Handlers;

namespace Komunikator_klient
{
    class Network
    {

        Socket sender;
        Dispatcher dispatcher;

        public Boolean start(String ip, String port)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, Int32.Parse(port));

                sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(remoteEP);
                dispatcher = new Dispatcher();

                Console.WriteLine("Połączono z {0}",
                       sender.RemoteEndPoint.ToString());
            }
            catch (Exception)
            {
                try
                {
                    Console.WriteLine("Wystąpił problem podczas połączenia z {0}",
                           sender.RemoteEndPoint.ToString());
                }catch (Exception)
                {
                    Console.WriteLine("Wystąpił problem podczas połączenia");
                }
                return false;
            }
            return true;
        }

        private void send(Message data)
        {  
            
            byte[] bytes = new byte[1024];
  
            try
            {
                // Encode the data string into a byte array.  
                byte[] msg = ObjectToByteArray(data);

                // Send the data through the socket.  
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.  
                int bytesRec = sender.Receive(bytes);

                //przerobić odbiór wiadomości
                //String recivedMsg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                //Console.WriteLine("Otrzymana informacja = {0}", recivedMsg);

                Message recivedMsg = (Message)ByteArrayToObject(bytes);

                dispatcher.processMessage(recivedMsg);

                // Release the socket.  
                //sender.Shutdown(SocketShutdown.Both);
                //sender.Close();

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        public void sendFileMetadata(string toUser, string fileName)
        {
            MSendingFile msg = new MSendingFile();
            msg.from = Main.getLoggedUser();
            msg.name = fileName;
            msg.to = toUser;
            send(msg);
        }

        public void sendFile(string filePath)
        {
            try
            {
                sender.SendFile(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił problem z wysłaniem pliku. " + e.ToString());
            }
        }

       private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        public  Boolean login(String login, String password)
        {
            MLogin structure = new MLogin();
            structure.login = login;
            structure.password = password;
            this.send(structure);
            return true; // zmienić nie ma być sztywne
            
        }

        public void register(String login, String password, String repeatPassword)
        {
            MRegister structure = new MRegister();
            structure.login = login;
            structure.password = password;
            //structure.repeatPassword = repeatPassword;
            this.send(structure);
            
        }
        public void logout(String loggedUser)
        {
            MLogout structure = new MLogout();
            structure.loggedUser = loggedUser;
            this.send(structure);

        }
        public void list()
        {
            MList structure = new MList();
            this.send(structure);
        }

        public void sendMsgTo(String to, String from, String msg)
        {
            MSendingMessage structure = new MSendingMessage();
            structure.to = to;
            structure.from = from;
            structure.text = msg;
            this.send(structure);
        }
    }
}
