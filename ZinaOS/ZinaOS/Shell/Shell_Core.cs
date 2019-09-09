using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Set = ZinaShell.ZinaShellSet;
using static ZinaShell.ZinaShellFunc;

namespace ZinaShell
{
    public class ZinaShellCore
    {
        public ZinaShellCore(string initPath = null)
        {
            Set.nowPath = DriveInfo.GetDrives()[0].Name;

            if (!string.IsNullOrWhiteSpace(initPath))
            {
                if (Directory.Exists(initPath))
                    Set.nowPath = initPath;
                else
                    ShellWriteError("Cannot find input path. Shell start with default path.");
            }
        }

        public void RunShell()
        {
            while (true)
            {
                string shellText = $"beta @ {Set.nowPath} > ";
                ShellWrite(shellText);

                ReadCommand();
            }
        }

        void ReadCommand()
        {
            string command = "";

            command = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(command))
                return;

            ShellWriteLine(command);
        }
    }
}