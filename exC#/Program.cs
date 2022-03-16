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
            Console.WriteLine("나의 이름은 " + args[0] + "입니다.");
            Console.WriteLine("국어: {0}, 영어: {1}, 수학: {2}", args[1], args[2], args[3]);
            // int kor, eng, math 이렇게 하면 안됨! 이유: 변수는 초기값을 무조건 지정해야함!
            // int kor = 0, eng = 0, math 이렇게 하면된다.
            // kor = int.Parse(args[1]);
            // eng = int.Parse(args[2]);
            // math = int.Parse(args[3]);

            int kor = int.Parse(args[1]);
            int eng = int.Parse(args[2]);
            int math = int.Parse(args[3]);
            
            int sum = kor + eng + math;
            double avg = sum / 3;
            Console.WriteLine("합계: {0} 평균: {1}", sum, avg);
            // 평균: {1:F1}은 90.0
            // 평균: {1:F2}은 90.00
        }   
    }
}
