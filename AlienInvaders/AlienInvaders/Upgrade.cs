using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVersion1
{
    class Upgrade
    {
        public int x;
        public int y;
        public int direction;
        public int secondDirection;
        public int type;

        public Upgrade(int xValue, int yValue, int d, int t, int sd = 0)
        {
            x = xValue;
            y = yValue;
            direction = d;
            secondDirection = sd;
            type = t;
        }
    }
}