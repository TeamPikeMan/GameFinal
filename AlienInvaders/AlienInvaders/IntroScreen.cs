using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienInvaders
{
    class IntroScreen
    {
        static public void PrintIntroScreen()
        {
            GameBody.ConsoleSetUp(80, 29);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n In a galaxy far far away, there was a planet called PESHO..\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" The people on this planet were living in peace but one day a horrible evil ");
            Console.WriteLine(" creature called GOSHO wanted to destroy the planet, just for fun....\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" But not everything was lost ....");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" \n There was a team of great engineers (mostly software) called themselves\n Team \"Pikeman\"");
            Console.WriteLine(" They united their forces and built a gret spaceship which had the potencial to\n save the planet...");
            Console.WriteLine(" Now the only thing that left to save the planet was a pilot as great as\n the ship... ");
            Console.WriteLine(" After huge casting and thousnds of volunteers you have been choosen to\n take part in this suicide mission...");
            Console.WriteLine(" You are the last hope of the planet PESHO... so try not to die before\n the Invaders");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n                 Team \"Pikeman\" presents ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n                      Alien Invaders ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n Press any key to begin the battle... ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n Powered by Pavel Pavlov /argidux/\n ");

            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.Clear();
        }
       
    }
}
