using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("부호입력 (+,-,*,/): ");
            string op = Console.ReadLine();

            Console.WriteLine("두 수 입력 : ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int result = 0;

            if (op == "+")
                result = a + b;
            else if (op == "-")
                result = a - b;
            else if (op == "*")
                result = a * b;
            else if (op == "/")
                result = a / b;
            else
                Console.WriteLine("연산자가 잘못되었습니다.");
            Console.WriteLine("{0} {1} {2} = {3}", a, op, b, result);
        }
    }
}
