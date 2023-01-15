using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendLogger
{
    internal class Con
    {
        internal static void Log(string Message)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("[");
            System.Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.Write("Friend Logger");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] ");
            System.Console.ForegroundColor = ConsoleColor.White;            

            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine(Message);
            System.Console.ResetColor();
        }        
    }
    internal static class WriteToCon
    {
        public static string WriteToConsole(this string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            return text;
        }

        public static string WriteToConsole(this string text, string AddText, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write("" + AddText);
            Console.ResetColor();
            return text;
        }

        public static string WriteLineToConsole(this string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
            return text;
        }

        public static string WriteLineToConsole(this string text, string AddText, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("" + AddText);
            Console.ResetColor();
            return text;
        }
    }
}

