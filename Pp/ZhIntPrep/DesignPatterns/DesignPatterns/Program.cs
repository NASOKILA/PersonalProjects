using DesignPatterns.DesignPatterns;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            AggregateRootPattern.ExecuteExample();

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            IteratorPattern.ExecuteExample();

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            AdapterPattern.ExecuteExample();

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            TemplatePattern.ExecuteExample();

            Console.WriteLine($"Press any key to exit ...");
            Console.ReadKey();
        }
    }
}

 