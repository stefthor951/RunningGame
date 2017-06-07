﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunningGame.Screens;
using System.Drawing;

namespace RunningGame.Classes
{
    class Player
    {
        public int x, y, initialY;
        public int counter, width, height;
        int yChange, yVelocity, forwardSpeed = 5, reverseSpeed = 3;
        int yAcceleration;

        public Player(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }

        public void airCheck()
        {
            if (GameScreen.jumping == true && GameScreen.inAir == false)
            {
                yAcceleration = 10;
                initialY = y;
                GameScreen.inAir = true;
            }

            if (GameScreen.inAir == true)
            {
                yChange += yAcceleration;
                //yVelocity += GameScreen.yAcceleration;
                yAcceleration--;

                if (y > 400 - height && counter > 0)
                {
                    y = 400 - height;
                    GameScreen.inAir = false;
                    GameScreen.jumping = false;
                }
                counter++;
            }

            else if (GameScreen.inAir == false)
            {
                yAcceleration = 0;
                counter = 0;
                yChange = 0;
            }
        }

        public bool PlatformCollision(Platform p, bool onPlatform)
        {
            Rectangle playerRec = new Rectangle(x, y, width, height);
            Rectangle platformRec = new Rectangle(p.x, p.y, p.xSize, p.ySize);

            if (playerRec.IntersectsWith(platformRec))
            {
                if (y < p.y && x > p.x && (x + width < p.x + p.ySize)) //if the player is above the platform and between its left and right x coordinate
                {
                    GameScreen.inAir = false;
                    y = p.y - height;
                    onPlatform = true;
                    return (onPlatform);
                }
            }
            return ((false));
        }
        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= reverseSpeed;
            }
            if (direction == "right")
            {
                x += forwardSpeed;
            }
        }
    }
}
