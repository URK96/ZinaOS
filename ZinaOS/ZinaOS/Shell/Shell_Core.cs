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

        private void ReadCommand()
        {
            string command = "";
            
            command = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(command))
                return;

            string[] commandToken = command.Split(" ");

            switch (commandToken[0])
            {
                case "cls":
                case "clear":
                    ShellClear();
                    break;
                case "mkdir":
                case "makedir":
                    MakeDir(commandToken[1]);
                    break;
                case "rm":
                case "remove":
                    Remove(commandToken[1]);
                    break;
                case "rmdir":
                case "removedir":
                    RemoveDir(commandToken[1], true);
                    break;
                case "cd":
                case "changedir":
                    ChangeDir(commandToken[1]);
                    break;
                case "ls":
                case "dir":
                case "listdir":
                    ListDirContents();
                    break;
                case "cat":
                case "get":
                    ReadFileContent(commandToken[1]);
                    break;
                case "ver":
                case "version":
                    ShellVerInfo();
                    break;
            }
        }
    }
}