using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriumIrcBotConsole
{
    public static class ConsolePlus
    {
        public static void Green(string format, params object[] arg)
        {
            Console.Write("[{0}]", DateTime.Now);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(format, arg);
            Console.ResetColor();
        }
    }
}