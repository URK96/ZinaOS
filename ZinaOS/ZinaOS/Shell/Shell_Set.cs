using System;
using System.Text;

namespace ZinaShell
{
    internal static class ZinaShellSet
    {
        internal static string shellEnvPath { get; set; }
        internal static string nowPath { get; set; }
        internal static int shellCount { get; set; }

        internal static readonly string shellVer = "20190909";

        internal static readonly string[] commandList =
        {
            "clear",
            "makedir",
            "remove",
            "changedir",
            "listdir",
            "version"
        };
    }
}