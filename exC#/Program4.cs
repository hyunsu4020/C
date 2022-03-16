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
            Console.Write("국어점수 ");
            int kor = int.Parse(Console.ReadLine());

            Console.Write("영어점수 ");
            int eng = int.Parse(Console.ReadLine());

            Console.Write("수학점수 ");
            int math = int.Parse(Console.ReadLine());

            int sum = kor + eng + math;
            double avg = sum / 3;
            Console.Write("총점 {0} 평균 {1:F1}", sum, avg);
        }   
    }
}
