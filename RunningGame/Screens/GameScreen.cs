using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunningGame.Classes;
using System.Windows.Forms;

namespace RunningGame.Screens
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        Player player;

        private void OnStart()
        {
            player = new Player(100, 250, 0, 0);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            player.jump();
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, Convert.ToInt16(player.x), Convert.ToInt16(player.y), 50, 50);
        }
    }
}
