using System;
using System.Text;
using Set = ZinaShell.ZinaShellSet;

namespace ZinaShell
{
    internal static class ZinaShellFunc
    {
        internal static void ShellWrite(string text, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.Write(text);
        }

        internal static void ShellWriteLine(string text, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
        }

        internal static void ShellWriteError(string errorMsg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMsg);
        }

        internal static void ShellWriteSuccess(string successMsg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(successMsg);
        }
    }
}