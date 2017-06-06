using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningGame.Classes
{
    class Platform
    {
        public int x, y, speed, xSize, ySize;

        public Platform(int _x, int _y, int _speed, int _xSize, int _ySize)
        {
            x = _x;
            y = _y;
            speed = _speed;
            xSize = _xSize;
            ySize = _ySize;
        }

        public void Move()
        {
            x -= speed;
        }


    }
}
