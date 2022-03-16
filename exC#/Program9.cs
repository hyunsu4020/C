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
            Console.Write("단 입력 : ");
            int dan = Convert.ToInt32(Console.ReadLine());
            
             for (i = 0; i < 10; i++)
                 Console.WriteLine("{0} X {1} = {2}", dan, i, dan*i);
        }   
    }
}
