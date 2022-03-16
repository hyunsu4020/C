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
            Console.Write("부호 입력 : ");
            string op = Console.ReadLine();
            Console.WriteLine("두 수 입력: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (cal == "+")
                Console.WriteLine("{0} {1} {2} = {3}", a, cal, b, a + b);
            else
                Console.WriteLine(0);
        }   
    }
}
