using System;
using System.IO;

namespace Level1
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchMethod.SearchFiles(@"C:\platform-tools", "txt");
            Console.ReadKey();
        }
    }
}
