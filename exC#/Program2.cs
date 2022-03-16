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
            Console.Write("이름 입력 : ");
            string name = Console.ReadLine();
            Console.WriteLine(name);

            Console.Write("나이 입력 : ");
            string sAge = Console.ReadLine();
            int age = Convert.ToInt32(sAge);
            Console.WriteLine(age);
        }   
    }
}
