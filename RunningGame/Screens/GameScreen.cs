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
using System.Threading;

namespace RunningGame.Screens
{
    public partial class GameScreen : UserControl
    {
        Player player;
        List<Platform> platformList = new List<Platform>();
        List<Image> runList = new List<Image>();
        List<Image> jumpList = new List<Image>();
        List<Image> landList = new List<Image>();

        Random randNum = new Random();
        public static bool inAir = true;
        bool jumping = false, landing = false;
        public static int yVelocity;
        int runCounter = 0, jumpCounter = 0, landCounter = 0;
        int tickCount = 0;
        bool leftArrowDown, rightArrowDown, spaceDown;
        string currentDirection = null;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        private void OnStart()
        {
            player = new Player(100, 250, playerPicture.Width, playerPicture.Height);
            Platform platform1 = new Platform(0, 350, 0, 900, 50);
            platformList.Add(platform1);
            Thread.Sleep(500);
            gameTimer.Enabled = true;

            //run images (I named them backwards :( )
            runList.Add(Properties.Resources.run8);
            runList.Add(Properties.Resources.run7);
            runList.Add(Properties.Resources.run6);
            runList.Add(Properties.Resources.run5);
            runList.Add(Properties.Resources.run4);
            runList.Add(Properties.Resources.run3);
            runList.Add(Properties.Resources.run2);
            runList.Add(Properties.Resources.run1);

            //jump images
            jumpList.Add(Properties.Resources.jump1);
            jumpList.Add(Properties.Resources.jump2);
            jumpList.Add(Properties.Resources.jump3);
            jumpList.Add(Properties.Resources.jump4);
            jumpList.Add(Properties.Resources.jump5);
            jumpList.Add(Properties.Resources.jump6);
            jumpList.Add(Properties.Resources.jump7);

            //land images
            landList.Add(Properties.Resources.jump1);
            landList.Add(Properties.Resources.land1);
            landList.Add(Properties.Resources.land2);
            landList.Add(Properties.Resources.land3);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    leftArrowDown = true;
                    break;
                case Keys.D:
                    rightArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Escape:
                    gameTimer.Stop();
                    MenuScreen ms = new MenuScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(ms);
                    form.Controls.Remove(this);

                    ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
                    //player.Clear();
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    leftArrowDown = false;
                    break;
                case Keys.D:
                    rightArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region player animation
            
            
            //playerPicture.X = player.x;
            tickCount++;
            if (inAir == false && jumping == false && landing == false)
            {
                playerPicture.Width = runList[runCounter].Width;
                playerPicture.Height = runList[runCounter].Height;
                playerPicture.BackgroundImage = runList[runCounter];
                if (tickCount % 4 == 0 && tickCount != 0)
                {
                    runCounter++;
                }
                if (runCounter > 7)
                {
                    runCounter = 0;
                }
            }
            if (jumping)
            {
                playerPicture.Width = jumpList[jumpCounter].Width;
                playerPicture.Height = jumpList[jumpCounter].Height;
                playerPicture.BackgroundImage = jumpList[jumpCounter];
                if (tickCount % 5 == 0 && jumpCounter < 6)
                {
                    jumpCounter++;
                }
                if (jumpCounter == 6)
                {
                    jumpCounter = 5;
                }
                if (inAir == false)
                {
                    jumpCounter++;
                    runCounter = 2;
                    jumping = false;
                    landing = true;
                    jumpCounter = 0;
                    tickCount = 0;
                }
            }
            if (landing)
            {
                playerPicture.Width = landList[landCounter].Width;
                playerPicture.Height = landList[landCounter].Height;
                playerPicture.BackgroundImage = landList[landCounter];
                if (tickCount % 5 == 0 && tickCount != 0)
                {
                    landCounter++;
                }
                if (landCounter == 4)
                {
                    runCounter = 7;
                    landing = false;
                    landCounter = 0;
                    tickCount = 0;
                }
            }
            player.width = playerPicture.Width;
            player.height = playerPicture.Height;
            #endregion
            #region player movement
            if (spaceDown == true && inAir == false)
            {
                player.jump();
                jumping = true;
            }
            if (leftArrowDown && rightArrowDown == false)
            {
                currentDirection = "left";
            }
            if (rightArrowDown && leftArrowDown == false)
            {
                currentDirection = "right";
            }
            else if (!leftArrowDown && !rightArrowDown)
            {
                currentDirection = null;
            }
            player.Move(currentDirection, this.Width);
            #endregion
            #region platform movement and collision
            foreach (Platform p in platformList)
            {
                player.PlatformCollision(p);
                p.y -= p.speed;
                if (p.y + p.xSize < 0)
                {
                    platformList.Remove(p);
                }
            }
            #endregion
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            e.Graphics.FillRectangle(brush, Convert.ToInt16(player.x), Convert.ToInt16(player.y), player.width, player.height);
            foreach (Platform p in platformList)
            {
                e.Graphics.FillRectangle(blackBrush, p.x, p.y, p.xSize, p.ySize);
            }
        }
    }
}
