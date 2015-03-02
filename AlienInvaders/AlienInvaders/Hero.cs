using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienInvaders
{
    class Hero
    {
        public int x;
        public int y;
        public int lives;
        public int score;
        public int powerUpLevel;
        public int missileSpeed;
    }
    
        public Hero()
        {
            this.x = 20;
            this.y = 20;
            this.lives = 2;
            this.score = 0;
            this.powerUpLevel = 2;

        }
        
        public void Move(int move,int[,] grid)
        {
            this.RemoveFromGrid(grid);
            if (move == 1) { y -=1; }
            if (move == -1) { y += 1; }
            if (move == 2) { x -=1; }
            if (move == -2) { x+=1; }
            this.PlaceInGrid(grid);
        }
        
        public void LevelUp() 
        {
            if(powerUpLevel<=1)
            { 
                powerUpLevel++;
            }
        }

        public void LifeUp()
        {
            lives++;
        }

        public void SpeedUp()
        {
            missileSpeed++;
        }


        public void PlaceInGrid(int[,] grid)
        {
            grid[x, y] = 10;
        }

        public void RemoveFromGrid(int[,] grid)
        {
            grid[x, y] = 0;
        }
}
