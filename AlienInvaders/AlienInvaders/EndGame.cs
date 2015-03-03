using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AlienInvaders
{
    partial class GameBody
    {
        static public void HighScore(Hero player)
        {
            try
            {
                string playerName="";
                do
                {
                    Console.Write("Input your Name:  ");
                    playerName = Console.ReadLine();
                    if (playerName.IndexOf('-') >= 0)
                    {
                        throw new FormatException("Invalid Name! Do not use '-");
                    }
                }
                while (playerName.Length < 3);

                Score current = new Score(playerName, player.score, DateTime.Now);

                string[] scores = System.IO.File.ReadAllLines("HighScore.txt");

                List<Score> tempScore = new List<Score>();

                for (int i = 0; i < scores.Length; i++)
                {
                    string[] temp = scores[i].Split('-');
                    if (temp != null)
                    {
                        tempScore.Add(new Score(temp[0], int.Parse(temp[1]), DateTime.Parse(temp[2])));
                    }
                }


                tempScore.Add(current);

                tempScore.Sort((x1, x2) => x1.points.CompareTo(x2.points));

                if (tempScore.Count == 11)
                {
                    tempScore.RemoveAt(10);
                }
                Console.Clear();
                List<string> output = new List<string>();

                foreach (var item in tempScore)
                {
                    output.Add(item.ToString());
                    Console.WriteLine(item.ToString());
                }

                System.IO.File.WriteAllLines("HighScore.txt", output.ToArray());
            }

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static public void PrintHighScore()
        {
            Console.Clear();
            string[] scores = System.IO.File.ReadAllLines("HighScore.txt");

            foreach (var item in scores)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        //===============================================================================================> LOSE SCREEN
        static public void LoseScreen(int h, int w)
        {
            

            Console.WindowHeight = 35;
            Console.BufferHeight = 35;
            Console.WindowWidth = 85;
            Console.BufferWidth = 85;
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("\n");
            Console.WriteLine("             ...OOOOO...                                                           ");
            Console.WriteLine("             ..$O...O..                                                            ");
            Console.WriteLine("          .  ..O. .,O.                                                             ");
            Console.WriteLine("          .  .=O...,O.                                                             ");
            Console.WriteLine("             .Z:..,IO.                                                             ");
            Console.WriteLine("           ..,O...:8+..                                                            ");
            Console.WriteLine("           ..8I...,O:.                                                             ");
            Console.WriteLine("   ..........O.. .,O:..                                                            ");
            Console.WriteLine("  .:O,,,,.....   ,,O:..                            ..                  ....        ");
            Console.WriteLine("  O8:,,..   .   .,,O:...           ...     ..  .   ..         . ...............    ");
            Console.WriteLine("  O,,,.         .,,8:...     ..  .+OI.   ...,OOOO8.....8OOO8,. $OOOOOOO..OOOOOOO.. ");
            Console.WriteLine("  O:,,.        ..,,O:.......... ..+OI.   ..OOZ...OOZ..OO...OO. $O+.......OO....OO. ");
            Console.WriteLine("  O:,,.          ,,O8OOOOOOOOOZ...+OI.   .,OO.. ..OO..OOO$.....$O=.......OO....OO. ");
            Console.WriteLine("  O:,,.           .,,,,,,,,..Z$...+OI.   .+O$.   .OO...,OOOOO..$OOOOOOZ..OOOOOOO.. ");
            Console.WriteLine("  O,,,.           .. . ......Z$...+OI.   ..OO..  .OO.+OI...,O8.$O+.......OO..ZOO.. ");
            Console.WriteLine("  O:,,.                ...IO8~....+O$+++++.7OO?.IOO+..OO$.~OO=.$O7+++++..OO...$OO. ");
            Console.WriteLine("  O~,,.         .. ....OOZ.... . .=$$$$$$7...=OOO~...  :OOOI.. I$$$$$$$..$$....?$$ ");
            Console.WriteLine("  .OZ,,.       ....?OO=...         ......    ..        ....    ........... ..  ... ");
            Console.WriteLine("  ..O,,,      ....O?...                 .    ..          .. .      .. ..   .. ...  ");
            Console.WriteLine("  ..O,,,     ....O...                                                              ");
            Console.WriteLine("  ..O,,,........O+.                                                                ");
            Console.WriteLine("  OOOOOOOOOOOOOOOOO.                                                               ");
            Console.WriteLine("  O$777777777777IIO.            BECAUSE OF YOU  (THE LAST HOPE OF THE PALNET)      ");
            Console.WriteLine("  O$777777777777IIO..                    THERE IS NO MORE PLANET....               ");
            Console.WriteLine("  O$777777777777IIO..                          SHAME ON YOU                        ");
            Console.WriteLine("  O$777777777777IIO.                                                               ");
            Console.WriteLine("  O$7777777777$7IIO.                                                               ");
            Console.WriteLine("  ZOOOOOOOOOOOOOO88.                                                               ");
            Console.WriteLine("  .. ..............                                                                ");
            Console.WriteLine("\n  press any key to exit...                                                                ");
            Thread.Sleep(700);

            while (true)
            {
                Console.Beep(2000, 10000);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    break;
                }
            }
            HighScore(player);
        }
        //===============================================================================================> LOSE SCREEN

        static void WinScreenNinja()
        {
            Console.WindowHeight = 35;
            Console.BufferHeight = 35;
            Console.WindowWidth = 85;
            Console.BufferWidth = 85;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("\n          Thanks to ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Telerik Academy®");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(", you have proven that you are truly ninja\n");
            Console.WriteLine("                    and saved the planet from space invaders!!!\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                                                 .,,.    ");
            Console.WriteLine("                                            ..;;;;;;;;;;:                        ");
            Console.WriteLine("                                         ...;;;;G000000f;;;:                     ");
            Console.WriteLine("                                      ;;;;;;i0000000000000f;;;                   ");
            Console.WriteLine("                                   ,;;;;00000000000000000000G;;;                 ");
            Console.WriteLine("  :;                             .;;;C00/\\/\\00000000000000000i;;.              ");
            Console.WriteLine("  ;;;:                        .;;;0000000/\\0000000000000000000t;;               ");
            Console.WriteLine("  :;00;;:                    ;;;000000000\\/00000000.   ;0000000;;:              ");
            Console.WriteLine("   ;;0000;;:                ;;t00  .00000000000; L000i   0000000;;;              ");
            Console.WriteLine("    ;1000G00;;:            ;;;00.i0000i     .G000.       0000001;;,              ");
            Console.WriteLine("     ;t000  000;;:        ,;;G00   :00.. ,,   000:      G000000t;;;,             ");
            Console.WriteLine("      ;i00G i  000;;:      ;;;000      .G000Gi        ,00000000000;;;:           ");
            Console.WriteLine("       ;;G00,  f,.0001;;   ,;;;;000000000000000000000000000000000000;;;:         ");
            Console.WriteLine("         ;;L00C   1C 000f;;  ,;;;;;;;f00000000000000000000000000000000i;;:       ");
            Console.WriteLine("           ;;;f00G   ;8:L00G;;.   ,;;;;;;;;;;;;;;;G00f;G0000000000000000;;;,     ");
            Console.WriteLine("             .;;;;C00t  ,80:000;;.             ;;1000;;G000000000000000000;;;.   ");
            Console.WriteLine("                 ,;;;;L00f .:  1001;,          ;;000f;00000;;t0000000000000G;;;  ");
            Console.WriteLine("                     .;;;;1000;    t0C;:      ,;0000G00000;;;;;10000000000000;;; ");
            Console.WriteLine("                          ,;;;;f000; 0000;;   ;;;;t000000;;,  ;;;00000C;;00000f;;");
            Console.WriteLine("                               .;;;;L0000000f;1G;0;00000;;     ,;;0000G;;;;88@;;;");
            Console.WriteLine("                                     :;;;t000000 0;;L;t;.       .;;;000;;;;8@8;;;");
            Console.WriteLine("       Pesho{0}                          ,;0  C1;L0;;,          ;;;;;;;;;;;;;:  ", (char)8482);
            Console.WriteLine("       Gosho{0}                           ;0001;;G8 8;                   ..      ", (char)8482);
            Console.WriteLine("                                         ;;;.  .;;;;,               . ..........    ");
            Console.WriteLine("                                              ...:..............,,,,,,,,...........");
            Console.WriteLine("                                                          ........................ ");
            Console.WriteLine("       press any key to exit...                                               ");

            Thread.Sleep(700);

            while (true)
            {
                Console.Beep(440, 500);
                Console.Beep(440, 500);
                Console.Beep(440, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 1000);
                Console.Beep(659, 500);
                Console.Beep(659, 500);
                Console.Beep(659, 500);
                Console.Beep(698, 350);
                Console.Beep(523, 150);
                Console.Beep(415, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 1000);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    break;
                }

                HighScore(player);
            }


        }
    }
}
