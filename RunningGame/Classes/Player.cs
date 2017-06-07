using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunningGame.Screens;

namespace RunningGame.Classes
{
    class Player
    {
        public double x, y, initialY;
        public int counter, width, height;
        int yChange, yVelocity, forwardSpeed = 5, reverseSpeed = 3;

        public Player(float _x, float _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }

        public void airCheck()
        {
            if (GameScreen.inAir == true)
            {
                if (counter == 0)
                {
                    initialY = y;
                }
                y = initialY - yChange;
                yChange += GameScreen.yAcceleration;
                //yVelocity += GameScreen.yAcceleration;
                GameScreen.yAcceleration--;

                if (y > 400 - height && counter > 0)
                {
                    y = 400 - height;
                    GameScreen.inAir = false;
                    GameScreen.jumping = false;
                }
                counter++;
            }
            else
            {
                GameScreen.yAcceleration = 0;
                counter = 0;
                yChange = 0;
            }
        }
        public int PlatformCollision(Platform p)
        {
            if (y > )
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
