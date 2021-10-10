using System;
using static System.Int32;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("There is no path defined!");
                return;
            }
            
            int maxRecursion = -1;
            int sectionSpace = 2;
            var isTreeSeparation = false;
            var isColoredOutput = false;
            
            try
            {
                for (var i = 1; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "/r" :
                            maxRecursion = Parse(args[++i]);
                            Console.WriteLine($"-> set max directory recursion to: {maxRecursion}");
                            break;
                        case "/t" :
                            isTreeSeparation = true;
                            if (args.Length <= i + 1 || !TryParse(args[++i], out sectionSpace))
                            {
                                sectionSpace = 2;
                                i--; // cause parameter for indentation wasnt find
                            }
                            Console.WriteLine($"-> set tree visualization with indentation: {sectionSpace}");
                            break;
                        case "/c" :
                            isColoredOutput = true;
                            Console.WriteLine("-> set colored file names");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Something went wrong! Message -> {e.Message}");
                return;
            }

            var command = new LSCommand(maxRecursion, isTreeSeparation, sectionSpace, isColoredOutput);
            Console.WriteLine("\n******* Output *******");
            command.RunCommand(args[0]);
        }
    }
}