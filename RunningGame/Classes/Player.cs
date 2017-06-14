using System;
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
        int yChange, forwardSpeed = 5, reverseSpeed = 3, yAcceleration;

        public Player(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            initialY = _y;
        }

        public void jump()
        {
            GameScreen.inAir = true;
            initialY = y;
            yAcceleration = 15;
        }

        //this code is trash delete later
        //public void airCheck()
        //{
        //    if (GameScreen.jumping == true && GameScreen.inAir == false)
        //    {
        //        yAcceleration = 20;
        //        initialY = y;
        //        GameScreen.inAir = true;
        //        GameScreen.jumping = false;
        //        counter = 1;
        //    }

        //    else if (GameScreen.inAir == true)
        //    {
        //        if (counter == 0)
        //        {
        //            initialY = y;
        //        }

        //        onPlatform = false;
        //        yChange += yAcceleration;
        //        y = initialY - yChange;
        //        yAcceleration--;

        //        counter++;
        //    }

        //    else if (onPlatform == true)
        //    {
        //        GameScreen.jumping = false;
        //        GameScreen.inAir = false;
        //        yAcceleration = 0;
        //        counter = 0;
        //        yChange = 0;
        //    }

        //}

        public void PlatformCollision(Platform p)
        {
            Rectangle playerRec = new Rectangle(x, y, width + 1, height + 1); //the plus ones are so that the player touching but not intersecting with a platform will still run the following code
            Rectangle platformRec = new Rectangle(p.x, p.y, p.xSize, p.ySize);

            if (playerRec.IntersectsWith(platformRec))
            {
                if (y < p.y && x + (width / 2) > p.x && (x + (width / 2) < p.x + p.xSize) && yAcceleration < 0) //if the player is above the platform and between its left and right x coordinate and if the player is descending
                {
                    GameScreen.inAir = false;
                    y = p.y - height;
                }
                else if (y > p.y && x > p.x && (x + width < p.x + p.ySize)) //if the player hits the bottom of a platform
                { 
                    yAcceleration = 0;
                }
                else if ((x + width) < p.x)
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
                yChange += yAcceleration;
                y = initialY - yChange;
                yAcceleration--;
            }
            else if (GameScreen.inAir == false)
            {
                yAcceleration = 0;
            }

        }

        public void Clear()
        {
            //yChange = forwardSpeed = reverseSpeed = yAcceleration = initialY = counter = 0;
            GameScreen.inAir = false;
        }
    }
}
