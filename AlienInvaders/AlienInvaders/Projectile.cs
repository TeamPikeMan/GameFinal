using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVersion1
{
    class Projectile
    {
        public int x;
        public int y;
        public int direction;
        public int direction2;
        public int speed;

        public Projectile()
        {
            x = 0;
            y = 0;
            direction = 1;
        }

        public Projectile(int xpos, int ypos, int d, int d2=0, int s=1)
        {
            x=xpos;
            y=ypos;
            direction = d;
            direction2 = d2;
            speed = s;


        }
