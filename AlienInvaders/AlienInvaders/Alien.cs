using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AlienInvaders
{
    class Alien
    {
        public int x;
        public int y;
        public int lives;
        public int reloadTime;
        public int reloadTimer;

        public Alien(int xpos, int ypos, int l, int r)
        {
            x = xpos;
            y = ypos;
            lives = l;
            Random rng = new Random();
            reloadTimer = r;
            reloadTime = rng.Next(0, r);

        }

        public void PlaceInGrid(int[,] grid)
        {
            if (lives == 1)
            {
                grid[x, y] = 1;
            }
            if (lives == 2)
            {
                grid[x, y] = 11;
            }
            if (lives == 3)
            {
                grid[x, y] = 111;
            }
        }

        public void RemoveFromGrid(int[,] grid)
        {
            grid[x, y] = 0;
        }

        public Upgrade Hit_Detect(List<Projectile> j, int[,] grid, Hero pl)
        {
            if (j.Exists(o => o.x == this.x && o.y == this.y && o.direction == -1) && this.lives > 0)
            {
                lives--;
                pl.score += 10;

                int index = j.FindIndex(o => o.x == this.x && o.y == this.y);
                j[index].RemoveFromGrid(grid);
                j.RemoveAt(index);
                if (lives == 0)
                {
                    this.RemoveFromGrid(grid);
                    pl.score += 100;
                    Random rng = new Random();
                    int getUpgrade = rng.Next(1, 100);
                    if (getUpgrade >= 95)
                    {
                        return new Upgrade(this.x, this.y, 1, rng.Next(0, 4), 0);
                    }
                    else
                        return null;

                }

                Thread hitAlien = new Thread(AlienHitSound);
                if (GameBody.player.lives > 1)
                {
                    hitAlien.Start();
                    hitAlien.Abort();
                }

            }
            return null;
        }
        
        
        static void AlienHitSound()
        {
            if (true)
            {
                Console.Beep(400, 100);
            } 
        }

        public Projectile Fire()
        {
            if (this.reloadTime == this.reloadTimer)
            {
                return new Projectile(x+1,y, 1);
            }
            else
            {
                return null;
            }
        }

        public void ProgressTime()
        {
            if (this.reloadTime > this.reloadTimer) { this.reloadTime = 0; }
            this.reloadTime++;
        }
    }
}
