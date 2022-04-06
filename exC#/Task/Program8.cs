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
            Console.Write("단 입력 : ");
            int a = int.Parse(Console.ReadLine());
            
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("{0} X {1} = {2}", a, i, a*i);
            }
        }   
    }
}
