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
        public int width, height;
        int yChange, forwardSpeed = 5, reverseSpeed = 4, yAcceleration = 0, counter;
        bool cameraPanning = false;

        List<Platform> platformList = new List<Platform>();

        public Player(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            initialY = _y;
        }

        public void HalfJump()
        {
            GameScreen.inAir = true;
            initialY = y;
            yAcceleration = 8;
        }

        public void jump()
        {
            GameScreen.inAir = true;
            initialY = y;
            yAcceleration = 16;
        }

        public bool PlatformCollision(Platform p)
        {
            Rectangle playerRec = new Rectangle(x, y, width + 1, height + 1); //the plus ones are so that the player touching but not intersecting with a platform will still run the following code
            Rectangle platformRec = new Rectangle(p.x, p.y, p.xSize, p.ySize);

            if (playerRec.IntersectsWith(platformRec))
            {
                //if the player is above the platform and between its left and right x coordinate and if the player is descending
                if (y < p.y && x + (width / 2) > p.x && (x + (width / 2) < p.x + p.xSize) && yAcceleration <= 0) 
                {
                    cameraPanning = false;
                    GameScreen.inAir = false;
                    y = p.y - height;
                    yAcceleration = 0;
                    yChange = 0;
                    return (true);
                }
                else if (y > p.y && x > p.x && (x + width < p.x + p.ySize)) //if the player hits the bottom of a platform
                { 
                    yAcceleration = 0;
                }
                else if (x < p.x) //if the player hits the left side of the platform
                {
                    x = p.x - width;
                }
                else if (x > p.x + p.xSize)
                {
                    x = p.x + width;
                }
            }
            else
            {
                GameScreen.inAir = true;
            }
            return (false);
        }
        public void Move(string direction, int screenWidth)
        {
            if (direction == "left")
            {
                x -= reverseSpeed;
            }
            if (direction == "right")
            {
                x += forwardSpeed;
            }
            if (x < 0) //if the player is too far to the left
            {
                x += reverseSpeed;
            }
            if (x > screenWidth - width) //if the player is too far to the left
            {
                x -= forwardSpeed;
            }
            if (GameScreen.inAir == true)
            {
                //if (initialY - yChange > 50)
                {
                    y = initialY - yChange;
                }
                yChange += yAcceleration;
                yAcceleration--;
            }
        }

        //public void CameraPan(Platform p)
        //{
        //    if (p.counter == 0)
        //    {
        //        p.initialY = p.y;
        //        cameraPanning = true;
        //    }
        //    p.counter++;
        //    p.y = p.initialY + yChange;
        //    //p.yChange += yAcceleration;

        //    //if (p.initialY > p.y)
        //    //{
        //    //    p.y = p.initialY;
        //    //    p.counter = 0;
        //    //    cameraPanning = false;
        //    //}
        //    if (y >= initialY)
        //    {
        //        p.y = p.initialY;
        //    }
            
        //}

        //public void CameraPan(Platform p)
        //{
        //    cameraPanning = true;
        //    //platformList.Add(p);
        //    //if (cameraPanning == true)
        //    {
        //        p.y += yAcceleration;
        //        if (yAcceleration < 0)
        //        {
        //            y = initialY - yChange;
        //        }
        //    }
        //    //yAcceleration--;

        //}
    }
}
