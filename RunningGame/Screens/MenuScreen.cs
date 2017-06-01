using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningGame.Screens
{
    public partial class MenuScreen : UserControl
    {
        int index = 0;
        int lastIndex = 0;
        bool leftKeyDown, rightKeyDown;

        public MenuScreen()
        {
            InitializeComponent();
        }

        private void MenuScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftKeyDown = false;
                    break;
                case Keys.Right:
                    rightKeyDown = false;
                    break;
            }
        }

        private void MenuScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lastIndex = index;
            Form form = this.FindForm();
            Graphics g = this.CreateGraphics();
            Pen whitePen = new Pen(Color.White, 5);
            //to make sure that if you click to the bottom or top you will go to the other end instead of just stopping
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (leftKeyDown == false)
                    {
                        leftKeyDown = true;
                        if (index != 0)
                            index--;
                        else
                        {
                            index = 3;
                        }
                    }
                    break;
                case Keys.Right:
                    if (rightKeyDown == false)
                    {
                        rightKeyDown = true;
                        if (index != 3)
                            index++;
                        else
                        {
                            index = 0;
                        }
                    }
                    break;

                case Keys.Escape:
                    Application.Exit();
                    break;

                //Selecting an option on the main menu
                case Keys.Space:
                    switch (index)
                    {
                        //start button
                        case 0:

                            GameScreen gs = new GameScreen();
                            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);

                            form.Controls.Add(gs);
                            form.Controls.Remove(this);

                            break;

                        //highscore button
                        case 1:

                            InstructionScreen ins = new InstructionScreen();

                            form.Controls.Add(ins);
                            form.Controls.Remove(this);

                            ins.Location = new Point((form.Width - ins.Width) / 2, (form.Height - ins.Height) / 2);
                            break;
                            

                        //option button
                        case 2:

                            HighscoreScreen hs = new HighscoreScreen();
                            form.Controls.Add(hs);
                            form.Controls.Remove(this);

                            hs.Location = new Point((form.Width - hs.Width) / 2, (form.Height - hs.Height) / 2);

                            break;

                        //exit button
                        case 3:

                            Application.Exit();
                            break;
                    }
                    break;
            }

            //set button to white if not clicked on
            switch (lastIndex)
            {
                case 0:
                    startLabel.ForeColor = Color.White;
                    break;
                case 1:
                    instructionLabel.ForeColor = Color.White;
                    break;
                case 2:
                    highscoreLabel.ForeColor = Color.White;
                    break;
                case 3:
                    exitLabel.ForeColor = Color.White;
                    break;
            }

            //set selected button to red
            switch (index)
            {
                case 0:
                    g.Clear(Color.Transparent);
                    g.DrawLine(whitePen, startLabel.Location.X, startLabel.Location.Y + startLabel.Size.Height, startLabel.Location.X + startLabel.Size.Width, startLabel.Location.Y + startLabel.Size.Height);
                    break;
                case 1:
                    g.Clear(Color.Transparent);
                    g.DrawLine(whitePen, instructionLabel.Location.X, instructionLabel.Location.Y + instructionLabel.Size.Height, instructionLabel.Location.X + instructionLabel.Size.Width, instructionLabel.Location.Y + instructionLabel.Size.Height);
                    break;
                case 2:
                    g.Clear(Color.Transparent);
                    g.DrawLine(whitePen, highscoreLabel.Location.X, highscoreLabel.Location.Y + highscoreLabel.Size.Height, highscoreLabel.Location.X + highscoreLabel.Size.Width, highscoreLabel.Location.Y + highscoreLabel.Size.Height);
                    break;
                case 3:
                    g.Clear(Color.Transparent);
                    g.DrawLine(whitePen, exitLabel.Location.X, exitLabel.Location.Y + exitLabel.Size.Height, exitLabel.Location.X + exitLabel.Size.Width, exitLabel.Location.Y + exitLabel.Size.Height);
                    break;
            }
        }
    }
}
