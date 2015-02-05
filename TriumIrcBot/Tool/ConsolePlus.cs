using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriumIrcBot.Tool
{
    public static class ConsolePlus
    {
        public static void WriteLine(ConsoleColor aColor, string aFormat, params object[] aParams)
        {
            Console.ResetColor();
            Console.Write("[{0:HH:mm:ss}]", DateTime.Now);
            Console.ForegroundColor = aColor;
            Console.WriteLine(aFormat, aParams);
            Console.ResetColor();
        }
    }
}
