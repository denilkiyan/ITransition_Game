using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Game
{
    internal class ArgsValidator
    {
        public static bool Validate(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                ErrorMessage("The number of parameters must be odd and have at least three parameters");
                HelpMessage("You can try to change parameters");
                return false;
            }

            for (int i = 0; i < args.Length; i++)
            {
                for (int j = i + 1; j < args.Length; j++)
                {
                    if (args[i] == args[j])
                    {
                        ErrorMessage("The method can't get same parameters");
                        HelpMessage("You can try to insert other parameters");
                        return false;
                    }
                }
            }

            return true;
        }

        private static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private static void HelpMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Help message: {message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
