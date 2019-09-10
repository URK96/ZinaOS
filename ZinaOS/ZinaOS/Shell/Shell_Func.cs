using System;
using System.Text;
using System.IO;
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

        internal static void ShellClear()
        {
            Console.Clear();
        }

        internal static void ShellVerInfo()
        {
            ShellWriteLine("ZinaShell - Shell for ZinaOS");
            ShellWriteLine("ver.")
        }



        internal static void MakeDir(string dirPath)
        {
            try
            {
                Directory(Path.Combine(Set.nowPath, dirPath));
            }
            catch (Exception ex)
            {
                ShellWriteError("Cannot create new directory!");
            }
        }

        internal static void Remove(string fileName)
        {
            string path = Path.Combine(Set.nowPath, fileName);

            try
            {
                if (File.Exists(path))
                    File.Delete(path);
                else
                    ShellWriteError("File does not exist!");
            }
            catch (Exception ex)
            {
                ShellWriteError("Cannot remove file!");
            }
        }

        internal static void RemoveDir(string dirName, bool isRecursive)
        {
            string path = Path.Combine(Set.nowPath, dirName);

            try
            {
                if (Directory.Exists(path))
                    Directory.Delete(path, isRecursive);
                else
                    ShellWriteError("Directory does now exist!");
            }
            catch (Exception ex)
            {
                ShellWriteError("Cannot remove directory!");
            }
        }

        internal static void ChangeDir(string path)
        {
            try
            {
                if (path == "..")
                {
                    if (Path.IsPathRooted(Set.nowPath))
                        ShellWriteError("Working directory is root!");
                    else
                        Set.nowPath = Directory.GetParent().ToString();
                }
                else if (string.IsNullOrWhiteSpace(path))
                    Set.nowPath = Path.GetPathRoot(Set.nowPath);
                else
                {
                    string setPath = Path.Combine(Set.nowPath, path);

                    if (Directory.Exists(setPath))
                        Set.nowPath = setPath;
                    else
                        ShellWriteError("Directory is not exists!");
                }
            }
            catch (Exception ex)
            {
                ShellWriteError("Cannot change working directory!");
            }
        }

        internal static void ListDirContents()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Set.nowPath);
                FileInfo[] subFileInfos = dirInfo.GetFiles();
                DirectoryInfo[] subDirInfos = dirInfo.GetDirectories();

                if (subFileInfos.Length == 0 && subDirInfos.Length == 0)
                {
                    ShellWrite("No files and directories", ConsoleColor.Magenta);
                }

                foreach (DirectoryInfo info in subDirInfos)
                    ShellWrite($"{info.Name}\t", ConsoleColor.DarkGreen);

                foreach (FileInfo info in subFileInfos)
                    ShellWrite($"{info.Name}\t", ConsoleColor.White);
            }
            catch (Exception ex)
            {
                ShellWriteError(ex.Message);
            }
        }
    }
}