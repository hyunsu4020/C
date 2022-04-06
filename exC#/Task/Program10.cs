using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dan, i;
            
            for (dan = 2; dan < 10; dan++)
            {
                for(i = 1; i < 10; i++)
                {
                    Console.WriteLine("{0} X {1} = {2}", dan, i, dan * i);
                }
                Console.WriteLine("\n");
            }
        }   
    }
}
