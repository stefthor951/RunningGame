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
        Player player;
        public static bool inAir = false;
        public bool jumping = false;
        public static int yAcceleration, yVelocity;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        private void OnStart()
        {
            player = new Player(100, 250);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (inAir == false && jumping == false)
                    {
                        jumping = true;
                        yAcceleration = 10;
                    }
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            player.airCheck();
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, Convert.ToInt16(player.x), Convert.ToInt16(player.y), 50, 50);
        }
    }
}
