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
        public string type;

        int platformWidth = 850;

        //public Platform(int _x, int _y, int _speed, int _xSize, int _ySize)
        //{
        //    x = _x;
        //    y = _y;
        //    speed = _speed;
        //    xSize = _xSize;
        //    ySize = _ySize;
        //}

        public Platform(string _type, int screenHeight)
        {
            type = _type;

            x = 1000;
            speed = 5;
            xSize = platformWidth;
            if (type == "start")
            {
                x = 0;
                y = 250;
                ySize = screenHeight - y;
            }
            if (type == "high")
            {
                y = 100;
                ySize = screenHeight - y;
            }
            if (type == "middle")
            {
                y = 250;
                ySize = screenHeight - y;
            }
            if (type == "low")
            {
                y = 350;
                ySize = screenHeight - y;
            }
        }

        public void Move()
        {
            x -= speed;
        }

        public void newPlatform()
        {

        }
    }
}
