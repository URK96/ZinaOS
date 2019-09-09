using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace ZinaOS
{
    public class ZinaShell
    {
        public void RunShell()
        {
            ReadCommand();
        }

        void ReadCommand()
        {
            string command = "";

            while (true)
            {
                Console.Write($"");

                command = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                    continue;
            }
        }
    }
}