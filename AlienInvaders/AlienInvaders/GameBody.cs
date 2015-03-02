using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameVersion1
{
    partial class GameBody
    {
        public static Hero player = new Hero();

        struct Score
        {
            public string name;
            public int points;
            public DateTime date;

            public Score(string playerName, int p, DateTime dateTime)
            {
                this.name = playerName;
                this.points = p;
                this.date = dateTime;
            }

            public string ToString()
            {
                return name + "-" + points.ToString() + "-" + date.ToString();
            }
        }
        static void Main(string[] args)
        {
            int h = 29;
            int w = 80;
            int tbBorder = 4;
            ConsoleSetUp(w, h);
            DrawBackGround(h, w);
            
            List<Alien> swarm = new List<Alien>();
            List<Projectile> missles = new List<Projectile>();
            List<Upgrade> upgrades = new List<Upgrade>();
            Random rng = new Random();
            int[,] matrix = new int[h - 2 * tbBorder, w / 2];

            string[] menuText = { "Start", "Options", "HighScore", "Exit" };

        Selection:
            int select = 0;
            PrintMenu(select, menuText, w);

            while (true)
            {
                
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.UpArrow && select >= 1)
                {
                    select--;
                }//move up selection
                if (userInput.Key == ConsoleKey.DownArrow && select <= menuText.Length - 2)
                {
                    select++;
                } //move down selection

                if (userInput.Key == ConsoleKey.Enter)
                {
                    break; //stop selection process
                } //user input


                PrintMenu(select, menuText, w); //custom print method
            }

            switch (select)
            {
                case 0:
                    ConsoleSetUp(w, h);
                    DrawBackGround(h, w);
                    RunGame(swarm, missles, upgrades, rng, matrix, tbBorder);
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Remains to be implemented");

                    Console.ReadLine();
                    goto Selection;
                case 2:
                    PrintHighScore();
                    goto Selection;
                case 3:
                    return;
                default:
                    break;
            }

            //RunGame(swarm, missles, rng, matrix, tbBorder);
        }

        static public void RunGame(List<Alien> swarm, List<Projectile> missles, List<Upgrade> upgrades, Random rng, int[,] matrix, int b)
        {
            string[] txtFile = System.IO.File.ReadAllLines("Level2.txt");
            for (int i = 0; i < txtFile.Length; i++)
            {
                string[] temp = txtFile[i].Split(',');
                swarm.Add(new Alien(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), rng.Next(20, 500)));
            }

            foreach (Alien ship in swarm)
            {
                ship.PlaceInGrid(matrix);
            }
            //string monitor = printGrid(matrix);
            // Console.Write(monitor);
            //Hero player = new Hero();
            player.PlaceInGrid(matrix);
            while (true)
            {
                int i = GameTurn(swarm, missles, upgrades, player, matrix, b);
                if (i == 0)
                {
                    //=============================================================================================> LOSE SCREEN
                    LoseScreen(29, 80);
                    //=============================================================================================> LOSE SCREEN
                    break;
                }
                if (swarm.Count == 0)
                {//win
                    Console.Clear();
                    WinScreenNinja();
                    break;
                }
              }

            //Console.Clear();
            //Console.WriteLine("Game Over");
            //Console.WriteLine(player.score);

            //HighScore(player);
        }

        static public int GameTurn(List<Alien> s, List<Projectile> p, List<Upgrade> upgrades, Hero h, int[,] grid, int b)
        {

            string monitor = printGrid(grid);
            PrintMonitorLine(monitor, h, b);

            //Fire
            foreach (Alien ship in s)
            {
                upgrades.Add(ship.Hit_Detect(p, grid, h));
                p.Add(ship.Fire());
                p.RemoveAll(o => o == null);
                ship.ProgressTime();                
            }

            s.RemoveAll(o => o.lives <= 0);
            upgrades.RemoveAll(o => o == null);
            
            foreach (Upgrade alien in upgrades)
            {
                alien.PlaceInGrid(grid);
                alien.MoveTimeProgress(grid);
                alien.HeroCatch(h, grid);
            }

            upgrades.RemoveAll(o => o.type == 5);
            
            foreach (Upgrade alien in upgrades)
            {
                if (alien.x == grid.GetLength(0) - 1 || alien.x == 0)
                {
                    alien.direction *= -1;
                    if (alien.y == grid.GetLength(1) - 1 || alien.y == 0)
                    {
                        alien.secondDirection *= -1;
                    }
                }
            }

            foreach (Projectile missle in p)
            {
                missle.PlaceInGrid(grid);
            }
            // 


            foreach (Projectile missle in p)
            {
                if (missle.x == grid.GetLength(0) - 1 || missle.x == missle.speed-1)
                {
                    missle.RemoveFromGrid(grid);
                }
                if (missle.y == grid.GetLength(1) - 1 || missle.y == 0)
                {
                    missle.RemoveFromGrid(grid);
                }
            }

            p.RemoveAll(o => o.x == grid.GetLength(0) - 1);
            p.RemoveAll(o => o.x == 0);

            p.RemoveAll(o => o.y == grid.GetLength(1) - 1);
            p.RemoveAll(o => o.y == 0);
            //
            //s.RemoveAll(o => o.lives <= 0);
            monitor = printGrid(grid);

            foreach (Projectile missle in p)
            {
                missle.TimeProgress(grid);
            }

            HeroMove(h, grid, p);
            h.Hit(p, grid);
            if(s.Count<=2)
            {
                int j = 0;
            }
            Thread.Sleep(100);

            if (h.lives > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
                static public void HeroMove(Hero h, int[,] grid, List<Projectile> p)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow && h.y >= 5)
                {
                    h.Move(1, grid);
                }
                if (userInput.Key == ConsoleKey.RightArrow && h.y <= grid.GetLength(1) - 3)
                {
                    h.Move(-1, grid);
                }
                if (userInput.Key == ConsoleKey.UpArrow && h.x >= 10)
                {
                    h.Move(2, grid);
                }
                if (userInput.Key == ConsoleKey.DownArrow && h.x < grid.GetLength(0) - 1)
                {
                    h.Move(-2, grid);
                }

                if (userInput.Key == ConsoleKey.Z )
                {
                    h.lives++;
                }
                if (userInput.Key == ConsoleKey.Spacebar)
                {

                    switch (h.powerUpLevel)
                    {
                        case 0:
                            p.Add(h.Fire(0));
                            Thread fireSound = new Thread(HeroProjSoundZero);
                            if (player.lives > 1)
                            {
                                fireSound.Start();
                            }
                            break;
                        case 1:
                            p.Add(h.Fire(0));
                            p.Add(h.Fire(-1));
                             Thread fireSound1 = new Thread(HeroProjSoundOne);
                            if (player.lives > 1)
                            {
                                fireSound1.Start();
                            }
                            break;
                        case 2:
                            p.Add(h.Fire(0));
                            p.Add(h.Fire(-1));
                            p.Add(h.Fire(1));
                             Thread fireSound2 = new Thread(HeroProjSoundTwo);
                            if (player.lives > 1)
                            {
                                fireSound2.Start();
                            }
                            break;
                        default:
                            break;
                    }

                }
            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
            }
        }


        static public void PrintMenu(int s, string[] menu, int w)
        {
            Console.Clear(); //refresh screen
            var total = w; //should be console width in final version
            Console.CursorVisible = false;
            for (int i = 0; i < menu.Length; i++) //printing cycle
            {
                int n = menu[i].Length % 2 == 0 ? 1 : 0; //take care of even lenght situation
                if (i == s) //set color for the selected option
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; //set color
                    Console.WriteLine((">  " + menu[i]).PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length - n)
                                   .PadRight(total));  //centering text
                    Console.ForegroundColor = ConsoleColor.White;//reset color
                }
                else
                {
                    Console.WriteLine(menu[i].PadLeft(((total - menu[i].Length) / 2)
                                            + menu[i].Length - n)
                                   .PadRight(total));
                }

            }
            // Console.WriteLine(s);
        }
       
    }