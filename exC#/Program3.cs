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
            string sKor = Console.ReadLine();
            int kor = Convert.ToInt32(sKor);

            Console.Write("영어점수 ");
            string sEng = Console.ReadLine();
            int eng = Convert.ToInt32(sEng);

            Console.Write("수학점수 ");
            string sMath = Console.ReadLine();
            int math = Convert.ToInt32(sMath);

            int sum = kor + eng + math;
            double avg = sum / 3;
            Console.Write("총점 {0} 평균 {1}", sum, avg);
        }   
    }
}
