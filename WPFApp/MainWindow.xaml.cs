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
using System.Configuration;
using DestinationUnknownLibrary;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Player player = null;
        public int roomIndex = 0;

        public MainWindow(Player user)
        {
            InitializeComponent();

            player = user;
            roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == player.Location);

            LoadPlayerInv();
            LoadRoomInfo();
            LoadRoomExits();

            TB_Dialog.Text = "Welcome to Ring Wars!";
        }

        private void LoadPlayerInv()
        {
            LB_PlayerInv.Items.Clear();
            foreach (Item item in player.Inventory)
            {
                LB_PlayerInv.Items.Add(item.Name);
            }
        }

        private void LoadRoomInfo()
        {
            LB_RoomInv.Items.Clear();
            foreach (Item item in Rooms.Room[roomIndex].Loot)
            {
                LB_RoomInv.Items.Add(item.Name);
            }

            L_EnemyName.Content = Rooms.Room[roomIndex].Mob[0].Name;
        }

        private void LoadRoomExits()
        {
            L_NExit.Content = "";
            L_EExit.Content = "";
            L_SExit.Content = "";
            L_WExit.Content = "";

            if (Rooms.Room[roomIndex].Exit[0] != -1)
            {
                L_NExit.Content = Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == Rooms.Room[roomIndex].Exit[0])].Name;
            }
            if (Rooms.Room[roomIndex].Exit[1] != -1)
            {
                L_EExit.Content = Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == Rooms.Room[roomIndex].Exit[1])].Name;
            }
            if (Rooms.Room[roomIndex].Exit[2] != -1)
            {
                L_SExit.Content = Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == Rooms.Room[roomIndex].Exit[2])].Name;
            }
            if (Rooms.Room[roomIndex].Exit[3] != -1)
            {
                L_WExit.Content = Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == Rooms.Room[roomIndex].Exit[3])].Name;
            }
        }

        private void Btn_RoomToPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                player.Inventory.Add(Rooms.Room[roomIndex].Loot[LB_RoomInv.SelectedIndex]);
                Rooms.Room[roomIndex].Loot.RemoveAt(LB_RoomInv.SelectedIndex);
                LB_RoomInv.Items.RemoveAt(LB_RoomInv.SelectedIndex);

                LoadPlayerInv();
            }
            catch 
            {
                MessageBox.Show("Please choose an Item from the room's inventory", "Error!");
            }
        }

        private void Btn_PlayerToRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rooms.Room[roomIndex].Loot.Add(player.Inventory[LB_PlayerInv.SelectedIndex]);
                player.Inventory.RemoveAt(LB_PlayerInv.SelectedIndex);
                LB_PlayerInv.Items.RemoveAt(LB_PlayerInv.SelectedIndex);

                LoadRoomInfo();
            }
            catch
            {
                MessageBox.Show("Please choose an Item from your inventory", "Error!");
            }
        }
    }
}
