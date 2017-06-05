using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningGame.Classes
{
    class Player
    {
        public double x, y, initialY, xSpeed, ySpeed;
        public int counter;

        public Player(float _x, float _y, float _xSlope, float _ySlope)
        {
            x = _x;
            y = _y;
            xSpeed = _xSlope;
            ySpeed = _ySlope;
        }

        public void jump()
        {
            if (counter == 0)
            {
                initialY = y;
            }

            y = Math.Sqrt(((counter)^2)+5*(counter)) + initialY;
            counter++;
        }
    }
}
