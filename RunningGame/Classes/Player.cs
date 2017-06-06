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
        public int counter;
        int yChange, yVelocity, forwardSpeed = 5, reverseSpeed = 3;

        public Player(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public void airCheck()
        {
            if (GameScreen.inAir == true)
            {
                if (counter == 0)
                {
                    initialY = y;
                }
                y = initialY + yChange;
                yChange += yVelocity;
                yVelocity += GameScreen.yAcceleration;
                GameScreen.yAcceleration--;

                counter++;
            }
            else
            {
                counter = 0;
            }
        }

        void Move(string direction)
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
