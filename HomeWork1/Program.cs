using System;
using System.IO;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }*/
            /*DirectoryInfo directory = new DirectoryInfo(@"C:\Users\lanya\Desktop\Fun\css");
            GetDirInfo(directory, 0, maxLevel);*/

            var command = new LSCommand(-1, true);
            command.RunCommand(@"C:\Users\lanya\Desktop\Fun\test");
        }
    }
}