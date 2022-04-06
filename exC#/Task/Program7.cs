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
            Console.WriteLine("정수를 입력하고 마지막에 0을 입력하세요 ");
            int n, sum = 0, count = 0;

            while (true)
            {
                n = int.Parse(Console.ReadLine());
                if (n == 0)
                    break;
                sum = sum + n;
                count++;
            }
            Console.WriteLine("수의 개수는 {0}개이며, 평균은 {1}입니다.", count, sum/count);
        }   
    }
}
