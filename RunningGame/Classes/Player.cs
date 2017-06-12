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
        public int counter, width, height;
        bool onPlatform, ableToMove;
        int yChange, forwardSpeed = 5, reverseSpeed = 3, yAcceleration;

        public Player(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }

        public void jump()
        {
                
        }

        public void airCheck()
        {
            if (GameScreen.jumping == true && GameScreen.inAir == false)
            {
                yAcceleration = 20;
                initialY = y;
                GameScreen.inAir = true;
                GameScreen.jumping = false;
                counter = 1;
            }

            else if (GameScreen.inAir == true)
            {
                if (counter == 0)
                {
                    initialY = y;
                }

                onPlatform = false;
                yChange += yAcceleration;
                y = initialY - yChange;
                yAcceleration--;

                counter++;
            }

            else if (onPlatform == true)
            {
                GameScreen.jumping = false;
                GameScreen.inAir = false;
                yAcceleration = 0;
                counter = 0;
                yChange = 0;
            }

        }

        public void PlatformCollision(Platform p)
        {
            Rectangle playerRec = new Rectangle(x, y, width, height);
            Rectangle platformRec = new Rectangle(p.x, p.y, p.xSize, p.ySize);

            if (playerRec.IntersectsWith(platformRec))
            {
                if (y < p.y && x + (width / 2) > p.x && (x + (width / 2) < p.x + p.xSize)) //if the player is above the platform and between its left and right x coordinate
                {
                    GameScreen.inAir = false;
                    y = p.y - height - 1;
                    yAcceleration = 0;
                    onPlatform = true;
                    
                }
                else if (y > p.y && x > p.x && (x + width < p.x + p.ySize)) //if the player hits the bottom of a platform
                {
                    yAcceleration = 0;
                    onPlatform = false;
                }
                else if ((x + width) < p.x)
                {
                    yAcceleration = 0;
                    x = p.x - width;
                    ableToMove = false;
                    onPlatform = false;

                }
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
        }

        public void Clear()
        {
            yChange = forwardSpeed = reverseSpeed = yAcceleration = initialY = counter = 0;
            GameScreen.inAir = GameScreen.jumping = false;
        }
    }
}
