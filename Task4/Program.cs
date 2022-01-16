using System;
using Workers;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var _watcher = new Watcher();
            bool tick = true;
            while (tick == true)
            {
                Console.WriteLine("Exit? Y/N");
                char k = Console.ReadKey().KeyChar;
                if (k == 'Y' || k == 'y')
                {
                    tick = false;                   
                    Console.WriteLine();                

                }
                else
                {
                    tick = true;
                    Console.WriteLine();
                }
            }
           
        }
    }
}
