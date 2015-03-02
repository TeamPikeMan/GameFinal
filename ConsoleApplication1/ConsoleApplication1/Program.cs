using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BasicBASIC
{
    public static Dictionary<string, long> Variables = new Dictionary<string, long>();

    public static SortedDictionary<int, List<string>> CommandLines = new SortedDictionary<int, List<string>>();

    public static string[] commands = new string[11];


    static void Main()
    {
        DefautVariables();
        Entercommands();
        while (true)
        {
            string tempLine = Console.ReadLine();
            if (tempLine == "RUN")
            {
                break;
            }
            if (tempLine.Length < 1)
            {
                continue;
            }

            string[] temp = new string[2];
            string lineCOmmands = tempLine;
            temp[0] = tempLine.Remove(tempLine.IndexOf(' '));
            temp[1] = tempLine.Substring(tempLine.IndexOf(' '));
            CommandLines[int.Parse(temp[0])] = ExtractCommands(temp[1]);
        }

        List<int> keyIndex = new List<int>();

        foreach (var key in CommandLines.Keys)
        {
            keyIndex.Add(key);
        }

        int oper = CommandLines.First().Key;
        bool stopper = true;
        int currIndex = 0;

        while (stopper)
        {

            switch (CommandLines[oper][0])
            {
                case "IF":

                case "THEN":
                case "CLS":
                case "PRINT":
                    Console.WriteLine(Variables[CommandLines[oper][1]]); stopper = false; oper = keyIndex[++currIndex]; break;

                case "STOP": break; break;
                //case    "=":
                //case    "+":
                //case    "-":
                //case    ">":
                //case    "<":
                //case  "GOTO":
                case "Z": Variables[CommandLines[oper][0]] = AssignVariables(CommandLines[oper]); stopper = false; oper = keyIndex[++currIndex]; break;
                case "X": Variables[CommandLines[oper][0]] = AssignVariables(CommandLines[oper]); stopper = false; oper = keyIndex[++currIndex]; break;
                case "Y": Variables[CommandLines[oper][0]] = AssignVariables(CommandLines[oper]); stopper = false; oper = keyIndex[++currIndex]; break;
                case "V": Variables[CommandLines[oper][0]] = AssignVariables(CommandLines[oper]); stopper = false; oper = keyIndex[++currIndex]; break;
                case "W": Variables[CommandLines[oper][0]] = AssignVariables(CommandLines[oper]); stopper = false; oper = keyIndex[++currIndex]; break;
                default: break;
            }
        }

        string test = CommandLines[5][0];
        Console.WriteLine(oper);

    }

    static long AssignVariables(List<string> command)
    {
        long result = Variables[command[0]];

        if (command.Count == 3)
        {
            if (Variables.Keys.Contains(command[2]))
            {
                result += Variables[command[2]];

            }
            else
            {
                result += long.Parse(command[2]);
            }

        }
        else if (command.Count == 4)
        {
            if (Variables.Keys.Contains(command[3]))
            {
                result -= Variables[command[3]];

            }
            else
            {
                result -= long.Parse(command[3]);
            }
        }
        else if (command.Count == 5)
        {
            if (command[3] == "-")
            {
                result -= Variables[command[2]] - Variables[command[4]];
            }
            if (command[3] == "+")
            {
                result += Variables[command[2]] - Variables[command[4]];
            }
        }



        return result;
    }


    static void Entercommands()
    {
        commands[0] = "IF";
        commands[1] = "THEN";
        commands[2] = "CLS";
        commands[3] = "PRINT";
        commands[4] = "STOP";
        commands[5] = "=";
        commands[6] = "+";
        commands[7] = "-";
        commands[8] = ">";
        commands[9] = "<";
        commands[10] = "GOTO";

    }

    static List<string> ExtractCommands(string line)
    {
        List<string> currLine = new List<string>();
        line = line.Replace(" ", "");

        string currNumber = "";

        for (int i = 0; i < line.Length; i++)
        {
            foreach (var command in commands)
            {
                if (line.IndexOf(command, i) == i)
                {
                    currLine.Add(command);
                }
            }

            foreach (var var in Variables.Keys)
            {
                if (line.IndexOf(var, i) == i)
                {
                    currLine.Add(var);
                }
            }

            if (Char.IsDigit(line[i]))
            {
                currNumber += (char)line[i];
                if (i < line.Length - 1 && !Char.IsDigit(line[i + 1]))
                {
                    currLine.Add(currNumber);
                    currNumber = "";
                }
                if (i == line.Length - 1)
                {
                    currLine.Add(currNumber);
                    currNumber = "";
                }
            }
        }

        return currLine;
    }

    static void DefautVariables()
    {
        Variables["Z"] = 0;
        Variables["X"] = 0;
        Variables["Y"] = 0;
        Variables["V"] = 0;
        Variables["W"] = 0;
    }
}