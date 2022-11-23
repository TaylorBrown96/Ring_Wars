/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System;
using System.Windows;
using System.Windows.Controls;
using RingWarsLibrary;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Player player = null;
        public int roomIndex = 0;
        public double mobHP = 0;

        public MainWindow(Player user)
        {
            InitializeComponent();

            player = user;
            roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == player.Location);

            LoadPlayerInv();
            LoadRoomInfo();
            LoadRoomMob();
            LoadRoomExits();

            TB_Dialog.Text = "Welcome to Ring Wars!\n";
        }

        private void LoadPlayerInv()
        {
            LB_PlayerInv.Items.Clear();
            foreach (Item item in player.Inventory)
            {
                LB_PlayerInv.Items.Add(item.Name);
            }

            PB_PlayerHealth.Value = player.HP;
        }

        private void LoadRoomInfo()
        {
            LB_RoomInv.Items.Clear();
            foreach (Item item in Rooms.Room[roomIndex].Loot)
            {
                LB_RoomInv.Items.Add(item.Name);
            }

            L_EnemyName.Content = "";
            if (Rooms.Room[roomIndex].Mob.Count != 0)
            {
                L_EnemyName.Content = Rooms.Room[roomIndex].Mob[0].Name;
            }
        }

        private void LoadRoomMob()
        {
            L_EnemyName.Content = "";
            if (Rooms.Room[roomIndex].Mob.Count != 0)
            {
                L_EnemyName.Content = Rooms.Room[roomIndex].Mob[0].Name;
                mobHP = Rooms.Room[roomIndex].Mob[0].HP;
                PB_EnemyHealth.Value = 100;
            }
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
                if (Rooms.Room[roomIndex].Loot[LB_RoomInv.SelectedIndex].Id >= 200 && Rooms.Room[roomIndex].Loot[LB_RoomInv.SelectedIndex].Id <= 299)
                {
                    player.Inventory.Insert(0, Rooms.Room[roomIndex].Loot[LB_RoomInv.SelectedIndex]);
                }
                else
                {
                    player.Inventory.Add(Rooms.Room[roomIndex].Loot[LB_RoomInv.SelectedIndex]);
                }

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

        private void Btn_ExamineItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Item item = player.Inventory[LB_PlayerInv.SelectedIndex];
                Weapons weapon = null;
                if (item.Id >=200 && item.Id <= 299)
                {
                    weapon = (Weapons)item;
                }

                if (weapon == null)
                {
                    TB_Dialog.AppendText("\n\nItem Stats:" +
                                         "\n\tItem Name: " + item.Name +
                                         "\n\tItem Description: " + item.Description +
                                         "\n\tItem Value: " + item.Price);
                }
                else
                {
                    TB_Dialog.AppendText("\n\nWeapon Stats:" + 
                                         "\n\tWeapon Name: " + item.Name +
                                         "\n\tWeapon Description: " + item.Description +
                                         "\n\tWeapon Value: " + item.Price +
                                         "\n\tWeapon Attack Damage: " + weapon.Damage +
                                         "\n\tWeapon Damage Type: " + weapon.DmgType);
                }
                
            }
            catch
            {
                MessageBox.Show("Please choose an Item from your inventory", "Error!");
            }
        }

        private void Btn_North_Click(object sender, RoutedEventArgs e)
        {
            if (Rooms.Room[roomIndex].Exit[0] != -1)
            {
                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == Rooms.Room[roomIndex].Exit[0]);
                LoadRoomExits();
                LoadRoomInfo();
                LoadRoomMob();
            }
            else
            {
                MessageBox.Show("There isnt an exit in that direction!", "Error!");
            }
        }

        private void Btn_East_Click(object sender, RoutedEventArgs e)
        {
            if (Rooms.Room[roomIndex].Exit[1] != -1)
            {
                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == Rooms.Room[roomIndex].Exit[1]);
                LoadRoomExits();
                LoadRoomInfo();
                LoadRoomMob();
            }
            else
            {
                MessageBox.Show("There isnt an exit in that direction!", "Error!");
            }
        }

        private void Btn_South_Click(object sender, RoutedEventArgs e)
        {
            if (Rooms.Room[roomIndex].Exit[2] != -1)
            {
                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == Rooms.Room[roomIndex].Exit[2]);
                LoadRoomExits();
                LoadRoomInfo();
                LoadRoomMob();
            }
            else
            {
                MessageBox.Show("There isnt an exit in that direction!", "Error!");
            }
        }

        private void Btn_West_Click(object sender, RoutedEventArgs e)
        {
            if (Rooms.Room[roomIndex].Exit[3] != -1)
            {
                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == Rooms.Room[roomIndex].Exit[3]);
                LoadRoomExits();
                LoadRoomInfo();
                LoadRoomMob();
            }
            else
            {
                MessageBox.Show("There isnt an exit in that direction!", "Error!");
            }
        }

        private void Btn_Attack_Click(object sender, RoutedEventArgs e)
        {
            if (Rooms.Room[roomIndex].Mob.Count == 0)
            {
                TB_Dialog.AppendText("\nThe moster has already been slain!\n");
                return;
            }
            if (player.Inventory[0].Id == 200)
            {
                if (Rooms.Room[roomIndex].Mob[0].HP > 0)
                {
                    Weapons weapon = (Weapons)player.Inventory[0];
                    int Player_AD = weapon.Damage;

                    Mobs mob = (Mobs)Rooms.Room[roomIndex].Mob[0];
                    int Mob_AD = Combat.Attack(mob.AD, Player_AD, roomIndex);

                    player.HP -= Mob_AD;
                    TB_Dialog.AppendText("\nThe Monster did "); TB_Dialog.AppendText(Convert.ToString(Mob_AD)); TB_Dialog.AppendText(" damage to you.\n");
                    TB_Dialog.AppendText("You did "); TB_Dialog.AppendText(Convert.ToString(Player_AD)); TB_Dialog.AppendText(" damage to the monster.\n");

                    PB_PlayerHealth.Value = player.HP;
                    PB_EnemyHealth.Value = Rooms.Room[roomIndex].Mob[0].HP / mobHP * 100;

                }

                if (Rooms.Room[roomIndex].Mob[0].HP <= 0)
                {
                    Mobs mob = (Mobs)Rooms.Room[roomIndex].Mob[0];
                    foreach (Item item in mob.Inventory)
                    {
                        Rooms.Room[roomIndex].Loot.Add(item);
                    }
                    Rooms.Room[roomIndex].Mob.RemoveAt(0);
                    TB_Dialog.AppendText("\nYou killed the foul beast!");
                    TB_Dialog.AppendText("\nYou were left with: "); TB_Dialog.AppendText(Convert.ToString(player.HP)); TB_Dialog.AppendText("HP\n");
                    LoadRoomInfo();
                }
                else
                {
                    TB_Dialog.AppendText("\nThe enemy still has " + Rooms.Room[roomIndex].Mob[0].HP + "HP\n");
                    TB_Dialog.AppendText("You have: "); TB_Dialog.AppendText(Convert.ToString(player.HP)); TB_Dialog.AppendText("HP\n");
                }
            }
            else if (player.Inventory[0].Id != 200)
            {
                TB_Dialog.AppendText("\nYou need to pick your weapon back up!\n");
            }
            if (player.HP > 0)
            {
                return;
            }

            // Displaying death message
            TB_Dialog.AppendText("\nYou Died!");
            TB_Dialog.AppendText("\nBetter luck next time!");
            TB_Dialog.AppendText("Press Enter to exit the program.");
            MessageBox.Show("You have met your demise", "You Died!");
            this.Close();
        }

        private void Btn_UseItem_Click(object sender, RoutedEventArgs e)
        {
            Potions item;

            try
            {
                item = (Potions)player.Inventory[LB_PlayerInv.SelectedIndex];

                if (player.HP == 100)
                {
                    MessageBox.Show("You can't use that item, you're already max health", "Error");
                }
                if (player.HP + item.Effects >= 101 )
                {
                    player.HP = 100;
                    player.Inventory.RemoveAt(LB_PlayerInv.SelectedIndex);
                    LB_PlayerInv.Items.RemoveAt(LB_PlayerInv.SelectedIndex);
                    PB_PlayerHealth.Value = 100;
                }
                else
                {
                    player.HP += item.Effects;
                    player.Inventory.RemoveAt(LB_PlayerInv.SelectedIndex);
                    LB_PlayerInv.Items.RemoveAt(LB_PlayerInv.SelectedIndex);
                    PB_PlayerHealth.Value = player.HP;
                }
            }
            catch
            {
                MessageBox.Show("You can't use that item like that.", "Error");
            }
        }

        private void TB_Dialog_TextChanged(object sender, TextChangedEventArgs e)
        {
            TB_Dialog.ScrollToEnd();
        }
    }
}
