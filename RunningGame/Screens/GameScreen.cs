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
        List<Platform> platformList = new List<Platform>();

        public static bool inAir = false;
        public static bool jumping = true;
        public static int yVelocity;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        private void OnStart()
        {
            player = new Player(100, 250, 50, 50);
            Platform platform1 = new Platform(75, 260, 0, 125, 50);
            platformList.Add(platform1);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    MenuScreen ms = new MenuScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(ms);
                    form.Controls.Remove(this);

                    ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
                    break;
                case Keys.Space:
                    if (inAir == false)// && jumping == false)
                    {
                        jumping = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            player.airCheck();
            foreach (Platform p in platformList)
            {
                 player.PlatformCollision(p);
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            e.Graphics.FillRectangle(brush, Convert.ToInt16(player.x), Convert.ToInt16(player.y), 50, 50);
            foreach (Platform p in platformList)
            {
                e.Graphics.FillRectangle(blackBrush, p.x, p.y, p.xSize, p.ySize);
            }
        }
    }
}
