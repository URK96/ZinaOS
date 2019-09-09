using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace ZinaOS
{
    public class Kernel : Sys.Kernel
    {
        ZinaShell zshell;

        protected override void BeforeRun()
        {
            Console.WriteLine("ZinaOS booted completely".);
            zshell = new ZinaShell();
        }

        protected override void Run()
        {
            zshell.RunShell();
        }
    }
}
