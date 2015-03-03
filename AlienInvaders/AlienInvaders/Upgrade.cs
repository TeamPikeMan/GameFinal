using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienInvaders
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
        public void PlaceInGrid(int[,] grid)
        {
            if (grid[x, y] == 0)
            {
                grid[x, y] = 5;
            }

        }

        public void RemoveFromGrid(int[,] grid)
        {
            if (grid[x, y] == 5)
            {
                grid[x, y] = 0;
            }
        }

        public void HeroCatch(Hero hero, int[,] grid)
        {
            if (this.x == hero.x && this.y == hero.y)
            {
                switch (type)
                {
                    case 1:
                        hero.LifeUp();
                        break;
                    case 2:
                        hero.LevelUp();
                        break;
                    case 3:
                        hero.score += 100;
                        break;
                    default:
                        break;

                }
                this.RemoveFromGrid(grid);
                type = 5;

            }
        }

        public void MoveTimeProgress(int[,] grid)
        {
            Random rng = new Random();
            this.RemoveFromGrid(grid);
            this.x += direction;
            this.y += secondDirection * rng.Next(0, 1);
            this.PlaceInGrid(grid);
        }
    }
}