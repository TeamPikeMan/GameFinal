using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienInvaders
{
    partial class GameBody
    {
        static public string printGrid(int[,] grid)
        {
            //Console.SetCursorPosition(0, 2);

            StringBuilder result = new StringBuilder();
            //StringBuilder[] lines= new StringBuilder[grid.GetLength(0)];


            for (int i = 0; i < grid.GetLength(0); i++)
            {
                //result.Append(new string('0', 5));
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    switch (grid[i, j])
                    {
                        case 0:
                            result.Append(" ");//space
                            break;
                        case 1:
                            result.Append(((char)376).ToString());//alien 1 live
                            break;
                        case 11: result.Append(((char)165).ToString());//alien 2 lives
                            break;
                        case 111: result.Append(((char)207).ToString());//alien 3 lives
                            break;
                        case 2:
                            result.Append(((char)8729).ToString());//alien bullet 
                            break;
                        case 3:
                            result.Append(((char)34).ToString());//hero bullet
                            break;
                        case 5:
                            result.Append("0");
                            break;
                        case 10:
                            result.Append(((char)9650).ToString());//hero 
                            break;
                        default:
                            break;
                    }
                }
                result.Append(System.Environment.NewLine);

            }

            return result.ToString();
        }

        static public void PrintMonitorLine(string s, Hero h, int b)
        {
            string[] lines = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(lines[i].Length / 2, b + i);
                Console.Write(lines[i]);
            }

            Console.SetCursorPosition(lines[1].Length / 2 + lines[0].Length + 2, b + 10);
            Console.Write(h.lives.ToString().PadLeft(5));



            Console.SetCursorPosition(lines[1].Length / 2 + lines[0].Length + 2, b + 12);
            Console.Write(h.score.ToString().PadLeft(5));

            //=============================================================================================> INSTRUCTIONS
            //Print game instructions below the playing field
            Console.SetCursorPosition(lines[1].Length / 2, lines[1].Length / 2 + 6);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("  ← → ↑ ↓ to move    spacebar to fire".ToString().PadRight(40));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            //Set cursor position within the playing field to clear score field bug
            Console.SetCursorPosition(lines[1].Length / 2, lines[0].Length / 2 + 4);
            //=============================================================================================> INSTRUCTIONS

            h.Print(lines[1].Length / 2, b);
        }

        static public void ConsoleSetUp(int h, int w)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WindowHeight = w;
            Console.BufferHeight = w;
            Console.WindowWidth = h;
            Console.BufferWidth = h;
            Console.CursorVisible = false;
        }

        static public void DrawBackGround(int h, int w)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string(' ', w * h));
            Console.BackgroundColor = ConsoleColor.Black;
            string gameTitle = " Space Invaders";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.Write((gameTitle).PadLeft(((w - gameTitle.Length) / 2)
                                            + gameTitle.Length)
                                   .PadRight(w));

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
