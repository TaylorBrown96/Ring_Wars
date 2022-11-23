/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System.Windows;
using RingWarsLibrary;

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
