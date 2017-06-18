using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy List.xaml
    /// </summary>
    public partial class List : Window
    {
        public List()
        {
            InitializeComponent();
            //Main.requestList();
        }

        public void setList(List<string> list) {
            listBox.Items.Clear();
            foreach (String user in list) {
                listBox.Items.Add(user);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string selectedUser = listBox.SelectedItem.ToString();

            Main.showChatWindow(selectedUser);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String loggedUser = Main.getLoggedUser();
            Main.logout(loggedUser);
        }
    }
}
