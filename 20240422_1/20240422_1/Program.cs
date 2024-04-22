using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240422_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1-1 사용자로부터 입력 받기
            //이름과 나이를 입력 받고 출력하는 코드를 작성하세요.
            //Console.Write("이름을 입력하세요: ");
            //string name = Console.ReadLine();
            //Console.Write("나이를 입력하세요: ");
            //string age = Console.ReadLine();
            //Console.WriteLine("안녕하세요, " + name + "! 당신은 : " + age + " 세 이군요.");


            //1-2 간단한 사칙연산 계산기 만들기
            //두 수를 입력 받고 사칙연산의 결과를 출력하세요.
            //Console.Write("첫 번째 수를 입력하세요: ");
            //string first = Console.ReadLine();
            //Console.Write("두 번째 수를 입력하세요: ");
            //string second = Console.ReadLine();
            //int num1 = int.Parse(first);
            //int num2 = int.Parse(second);
            //Console.WriteLine("더하기: " + (num1 + num2));
            //Console.WriteLine("빼기: " + (num1 - num2));
            //Console.WriteLine("곱하기: " + (num1 * num2));
            //Console.WriteLine("나누기: " + (num1 / num2));

            //1-3 온도 변환기 만들기
            //사용자로부터 섭씨온도를 입력받아, 화씨온도로 변환하는 프로그램을 만들어봅시다.  공식은 화씨 = (섭씨 * 9/5) + 32 입니다.
            //Console.Write("섭씨 온도를 입력하세요:");
            //string sub = Console.ReadLine();
            //float hwa = ((float.Parse(sub) * 9/5) + 32);
            //Console.WriteLine("변환된 화씨 온도: " + hwa);

            //1-4 BMI계산기 만들기
            //사용자로부터 키(m)와 체중(kg)를 입력받아, BMI 지수를 계산하는 프로그램을 만들어봅시다. 공식은 BMI = 체중(kg) / 키(m)^2 입니다.
            Console.Write("키를 입력하세요(m):");
            string height = Console.ReadLine();
            Console.Write("체중을 입력하세요(kg):");
            string weight = Console.ReadLine();
            double bmi = double.Parse(weight) / Math.Pow(double.Parse(height), 2);
            Console.WriteLine("BMI: " + bmi);



        }
    }
}
