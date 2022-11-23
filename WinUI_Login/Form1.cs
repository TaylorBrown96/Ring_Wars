using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RingWarsLibrary;
using WinUI_Game;
namespace WinUI_Login
{
    public partial class Form1 : Form
    {
        public Player player = null;
        public Form1(Player user)
        {
            InitializeComponent();
            player = user;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            var game = new WinUI_Game.Form1(player);
            game.Show();
        }
    }
}
