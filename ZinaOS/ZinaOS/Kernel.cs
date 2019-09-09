using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using ZinaShell;
using System.Threading;

namespace ZinaOS
{
    public partial class Kernel : Sys.Kernel
    {
        ZinaShellCore zshell;

        protected override void BeforeRun()
        {
            try
            {
                var fs = new Sys.FileSystem.CosmosVFS();
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

                Thread.Sleep(1000);

                Console.WriteLine("ZinaOS booted completely!");

                Thread.Sleep(1000);

                Console.Clear();
                Console.WriteLine("Welcome to ZinaOS alpha");
                zshell = new ZinaShellCore();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        protected override void Run()
        {
            zshell.RunShell();
        }
    }
}
