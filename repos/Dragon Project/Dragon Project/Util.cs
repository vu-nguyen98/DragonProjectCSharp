using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class Util
    {
        internal static void SPause()
        {
            System.Threading.Thread.Sleep(500);
        }

        internal static void MPause()
        {
            System.Threading.Thread.Sleep(750);
        }

        internal static void LPause()
        {
            System.Threading.Thread.Sleep(1000);
        }

        internal static void WriteLineInRed(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        internal static void WriteInRed(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        internal static void WriteInGreen(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(value);
            Console.ResetColor();
        }

        internal static void WriteLineInGreen(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(value);
            Console.ResetColor();
        }

        internal static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey(true);
        }
    }
}
