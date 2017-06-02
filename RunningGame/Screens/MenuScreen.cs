﻿using System;
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
        bool leftKeyDown, rightKeyDown, choiceChanged = false;
        Graphics g;
        Pen whitePen;

        public MenuScreen()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            whitePen = new Pen(Color.White, 5);
            
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            g.DrawLine(whitePen, startLabel.Location.X, startLabel.Location.Y + startLabel.Size.Height, startLabel.Location.X + startLabel.Size.Width - 5, startLabel.Location.Y + startLabel.Size.Height);
        }

        private void MenuScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftKeyDown = false;
                    choiceChanged = false;
                    break;
                case Keys.Right:
                    rightKeyDown = false;
                    choiceChanged = false;
                    break;
            }
        }

        private void MenuScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Form form = this.FindForm();
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
                        //If the start button is selected
                        case 0:

                            GameScreen gs = new GameScreen();
                            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);

                            form.Controls.Add(gs);
                            form.Controls.Remove(this);

                            break;

                        //If the instruction button is selected
                        case 1:

                            InstructionScreen ins = new InstructionScreen();

                            form.Controls.Add(ins);
                            form.Controls.Remove(this);

                            ins.Location = new Point((form.Width - ins.Width) / 2, (form.Height - ins.Height) / 2);
                            break;
                            

                        //If the highscore button is selected
                        case 2:

                            HighscoreScreen hs = new HighscoreScreen();
                            form.Controls.Add(hs);
                            form.Controls.Remove(this);

                            hs.Location = new Point((form.Width - hs.Width) / 2, (form.Height - hs.Height) / 2);

                            break;

                        //If the exit button is selected
                        case 3:

                            Application.Exit();
                            break;
                    }
                    break;
            }

            //set selected button to red
            switch (index)
            {
                case 0:
                    if (choiceChanged == false)
                    {
                        choiceChanged = true;
                        g.Clear(Color.Maroon);
                        g.DrawLine(whitePen, startLabel.Location.X, startLabel.Location.Y + startLabel.Size.Height, startLabel.Location.X + startLabel.Size.Width - 5, startLabel.Location.Y + startLabel.Size.Height);
                    }
                    break;
                case 1:
                    if (choiceChanged == false)
                    {
                        choiceChanged = true;
                        g.Clear(Color.Maroon);
                        g.DrawLine(whitePen, instructionLabel.Location.X, instructionLabel.Location.Y + instructionLabel.Size.Height, instructionLabel.Location.X + instructionLabel.Size.Width, instructionLabel.Location.Y + instructionLabel.Size.Height);
                    }
                    break;
                case 2:
                    if (choiceChanged == false)
                    {
                        choiceChanged = true;
                        g.Clear(Color.Maroon);
                        g.DrawLine(whitePen, highscoreLabel.Location.X, highscoreLabel.Location.Y + highscoreLabel.Size.Height, highscoreLabel.Location.X + highscoreLabel.Size.Width, highscoreLabel.Location.Y + highscoreLabel.Size.Height);
                    }
                    break;
                case 3:
                    if (choiceChanged == false)
                    {
                        choiceChanged = true;
                        g.Clear(Color.Maroon);
                        g.DrawLine(whitePen, exitLabel.Location.X, exitLabel.Location.Y + exitLabel.Size.Height, exitLabel.Location.X + exitLabel.Size.Width - 5, exitLabel.Location.Y + exitLabel.Size.Height);
                    }
                    break;
            }
        }
    }
}
