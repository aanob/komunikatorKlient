using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Komunikator_klient
{
    class Main
    {
        #region VARIABLES
        private static Network network;
        private static Window window;
        private static String loggedUser;
        private static TempArchive archive;
        private static ChatWindows chatWindows;
        #endregion

        #region METHODS
        public static void setWindow(Window window)
        {
            if (Main.window != null) Main.window.Close();
            Main.window = window;
            Main.window.Show();
        }

        public static Boolean ConnectToServer(String ip, String port) {
            
            if (getNetwork().start(ip, port) == true) {
                setWindow(new Login());

                return true;
            }
            else {
                return false;
            }

        }

        public static void login(String login, String password)
        {
            getNetwork().login(login, password); 

            if(archive == null)
            {
                archive = new TempArchive();
            }

            if (chatWindows == null)
            {
                chatWindows = new ChatWindows();
            }
        }

        public static void register(String login, String password, String repeatPassword)
        {
            getNetwork().register(login, password, repeatPassword);
        }
        public static void logout(String loggedUser)
        {
            getNetwork().logout(Main.loggedUser);
        }

        public static void requestList()
        {
            getNetwork().list();
        }

        public static void setUserList(List<String> userList) {
            ((List)window).setList(userList);
        }

        public static void sendMsgTo(String to, String from, String msg)
        {
            getNetwork().sendMsgTo(to, from, msg);   
        }

        public static void receiveMsg(String text, String fromUser) {
            archive.save(fromUser, text , false);
            chatWindows.displayWindow(fromUser);
        }

        public static void saveOwnMsg(String text, String fromUser)
        {
            archive.save(fromUser, text, true);
        }
        

        public static void showChatWindow(String fromUser)
        {
            chatWindows.displayWindow(fromUser);
        }
        public static List<MessagesFromUserArchive> readMsgFromArichve(String fromUser) {
           return archive.read(fromUser);
        }
        public static void sendFile(string toUser, string filePath)
        {
            string fileName = filePath.Substring(filePath.LastIndexOf("\\")+1);
            getNetwork().sendFileMetadata(toUser, fileName); 
            getNetwork().sendFile(filePath);
        }

        #endregion

        #region GETTERS AND SETTERS
        public static Network getNetwork()
        {
            if (network == null)
            {
                network = new Network();
            }
            return network;
        }
        
        public static void setLoggedUser(String userName)
        {
            loggedUser = userName;
        }
        public static String getLoggedUser()
        {
            return loggedUser;
        }
        #endregion

    }
}
