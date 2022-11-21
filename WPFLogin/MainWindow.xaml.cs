using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DestinationUnknownLibrary;

namespace WPFLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Player player = null;

        public MainWindow(Player user)
        {
            InitializeComponent();
            player = user;

            L_Username.Content = player.Name;
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            string usrInp = PB_Password.Password.ToString();

            if (usrInp == player.Password)
            {
                LoadGame();
            }
            else
            {
                MessageBox.Show("Sorry but that password was incorrect!", "Error!");
            }
        }

        private void LoadGame()
        {
            var game = new WPFApp.MainWindow(player);
            game.Show();
            this.Close();
        }
    }
}
