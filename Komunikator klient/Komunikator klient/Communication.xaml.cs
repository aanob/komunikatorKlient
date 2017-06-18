using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Komunikator_klient
{
    /// <summary>
    /// Logika interakcji dla klasy Communication.xaml
    /// </summary>
    public partial class Communication : Window
    {
        public Communication(String user)
        {
            InitializeComponent();
            lUsernsame.Content = user;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.saveOwnMsg(messageToSend.Text, lUsernsame.Content.ToString());
            Main.sendMsgTo(lUsernsame.Content.ToString(), Main.getLoggedUser(), messageToSend.Text);
            messageToSend.Text = "";
        }

        public void refresh()
        {
            TBMsgs.Text = "";
            List<MessagesFromUserArchive> msgsList = Main.readMsgFromArichve(lUsernsame.Content.ToString());
            if (msgsList == null) return;
            foreach (MessagesFromUserArchive msg in msgsList)
            {
                if (msg.fromMe)
                {
                    TBMsgs.Text += "\n" + msg.date + " " + Main.getLoggedUser() + ": " + msg.text;
                }
                else
                {
                    TBMsgs.Text += "\n" + msg.date + " " + lUsernsame.Content.ToString() + ": " + msg.text;
                }
            }
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bSendFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog theDialog = new Microsoft.Win32.OpenFileDialog();
            if (theDialog.ShowDialog() == true)
            {
                //byte[] fileBytes = File.ReadAllBytes(theDialog.FileName);
                //Main.saveOwnMsg("wysyła plik " + theDialog.FileName, lUsernsame.Content.ToString());
                //refresh();
                Main.sendFile(lUsernsame.Content.ToString(), theDialog.FileName);
            }
        }
    }
}



