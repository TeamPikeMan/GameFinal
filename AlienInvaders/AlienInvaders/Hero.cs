using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;

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

        //hero's properties in the beginning of the game
        public Hero()
        {
            this.x = 20;
            this.y = 20;
            this.lives = 2;
            this.score = 0;
            this.powerUpLevel = 0;

        }
        //move the hero on the console
        public void Move(int move, int[,] grid)
        {
            this.RemoveFromGrid(grid);
            if (move == 1) { y -= 1; }
            if (move == -1) { y += 1; }
            if (move == 2) { x -= 1; }
            if (move == -2) { x += 1; }
            this.PlaceInGrid(grid);
        }
        //when a bonus is caught upgrades the firing power of the hero
        public void LevelUp()
        {
            if (powerUpLevel <= 1)
            {
                powerUpLevel++;
            }
        }
        //when a bonus is caught increases the lives of the hero
        public void LifeUp()
        {
            lives++;
        }
        //intended to increase the speed of the missiles, not used currently
        public void SpeedUp()
        {
            missileSpeed++;
        }
        //Place or remove the hero from the grid
        public void PlaceInGrid(int[,] grid)
        {
            grid[x, y] = 10;
        }
        public void RemoveFromGrid(int[,] grid)
        {
            grid[x, y] = 0;
        }
        //create a projectile when hero fires
        public Projectile Fire(int i)
        {
            return new Projectile(x - 1, y, -1, i);
        }
        //when the hero is hit remove lives, changes sounds
        public void Hit(List<Projectile> j, int[,] grid)
        {
            if (j.Exists(o => o.x == this.x && o.y == this.y && o.direction == 1))
            {
                lives--;
                int index = j.FindIndex(o => o.x == this.x && o.y == this.y && o.direction == 1);
                j[index].RemoveFromGrid(grid);
                j.RemoveAt(index);
                if (GameBody.player.lives >= 1)
                {
                    Thread hit = new Thread(HeroHisSound);
                    hit.Start();
                }

                bool sound = true;
                if (GameBody.player.lives == 1)
                {
                    Thread lowBlood = new Thread(HeroLowLiveSound);
                    if (sound == true)
                    {
                        lowBlood.Start();
                        sound = false;
                    }
                }
                if (GameBody.player.lives > 1)
                {
                    sound = true;
                }
            }
        }
        //changes sound when hero is low on lives
        static void HeroLowLiveSound()
        {
            int i = 741;

            while (GameBody.player.lives == 1)
            {
                if (GameBody.player.lives == 0)
                {
                    break;
                }
                Thread.Sleep(i);
                if (i > 120)
                {
                    Console.Beep(1000, 120);
                    Console.Beep(1000, 100);
                    i -= 50;

                }
                else
                {
                    Console.Beep(2000, 120);
                    Console.Beep(2000, 120);
                }
            }
        }
        //sound when hero is hit
        static void HeroHisSound()
        {
            Console.Beep(300, 100);
        }
        //print hero in different color depending on the number of lives
        public void Print(int bx, int by)
        {
            Console.SetCursorPosition(y + bx, x + by);
            if (lives >= 3) { Console.ForegroundColor = ConsoleColor.Green; }
            if (lives == 2) { Console.ForegroundColor = ConsoleColor.Yellow; }
            if (lives == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.Write(((char)9650).ToString());

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(bx, x + by);
        }
    }
}
