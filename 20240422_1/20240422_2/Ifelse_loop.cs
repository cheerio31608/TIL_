using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240422_2
{
    class Ifelse_loop
    {
        //2-4. 소수 판별하기 메서드
        // 주어진 숫자가 소수인지 판별하는 함수
        static bool IsPrime(int num)
        {
            if (num <= 1) // 1보다 작거나 같은 수는 소수가 아니다.
            {
                return false;
            }
            for (int i = 2; i * i <= num; i++) // 2부터 숫자의 제곱근까지만 확인한다.
            {
                if (num % i == 0) // 숫자가 i로 나누어 떨어진다면 소수가 아니다.
                {
                    return false;
                }
            }
            return true; // 소수인 경우
        }

        static void Main(string[] args)
        {
            //2-1 구구단 출력하기
            //1부터 9까지의 숫자를 각각 1부터 9까지 곱한 결과를 출력하는 프로그램을 작성해보세요. 
            //for(int i=1; i<10; i++)
            //{
            //    for(int j=1; j<10; j++)
            //    {
            //        Console.WriteLine(i + " x " + j + " = " + i * j);
            //    }
            //}

            //2-2 별 찍기
            //1. **오른쪽으로 기울어진 직각삼각형 출력하기**:
            //-이 부분에서는 for 루프를 사용하여 오른쪽으로 기울어진 직각삼각형을 출력하는 프로그램을 작성해야 합니다.삼각형의 높이는 5입니다.
            //for(int i=0; i<5; i++)
            //{
            //    for(int j=0; j<i+1; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine(" ");
            //}
            //2. **역직각삼각형 출력하기**:
            //-역직각삼각형을 출력하는 프로그램을 작성해야 합니다. 이 삼각형의 높이 역시 5입니다.
            //for (int i = 5; i > 0; i--)
            //{
            //    for (int j = 0; j <i; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine(" ");
            //}
            //3. **피라미드 출력하기**:
            //-피라미드를 출력하는 프로그램을 작성해야 합니다. 이 피라미드의 높이는 5입니다.
            //for (int i = 1; i <=5; i++)
            //{
            //    for (int k = 5 - i; k > 0; k--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int j = 1; j <= (i*2)-1; j++) //4 3~5 2~6 1~7 0~8
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine(" ");
            //}

            //2-3. 최대값, 최소값 찾기
            //사용자로부터 일련의 숫자를 입력받아, 그 중에서 최대값과 최소값을 찾는 프로그램을 작성해보세요.
            //int[] arr = new int[5];
            //for(int i=0; i<5; i++)
            //{
            //    Console.Write("숫자를 입력하세요: ");
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //int max = arr[0]; int min = arr[0];
            //for(int i=1; i<5; i++)
            //{
            //    if (arr[i] > max) max = arr[i];
            //    else if (arr[i] < min) min = arr[i];
            //}
            //Console.WriteLine("최대값: " + max);
            //Console.WriteLine("최소값: " + min);

            //2-4. 소수 판별하기
            //Console.Write("숫자를 입력하세요: "); // 사용자에게 숫자 입력 요청
            //int num = int.Parse(Console.ReadLine()); // 사용자가 입력한 값을 정수로 변환하여 저장

            //if (IsPrime(num)) // 입력 받은 숫자가 소수라면
            //{
            //    Console.WriteLine(num + "은 소수입니다."); // 소수임을 출력
            //}
            //else // 소수가 아니라면
            //{
            //    Console.WriteLine(num + "은 소수가 아닙니다."); // 소수가 아님을 출력
            //}

            //2-5. 숫자 맞추기
            //컴퓨터는 1에서 100까지의 숫자를 임의로 선택하고, 사용자는 이 숫자를 맞추어야 합니다.
            //사용자가 입력한 숫자가 컴퓨터의 숫자보다 크면 "너무 큽니다!"라고 알려주고, 작으면 "너무 작습니다!"라고 알려줍니다.
            //사용자가 숫자를 맞추면 게임이 종료됩니다.
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int numberOfTries = 0;
            bool isNumberGuessed = false;

            Console.WriteLine("숫자 맞추기 게임을 시작합니다. 1에서 100까지의 숫자 중 하나를 맞춰보세요.");

            while (!isNumberGuessed)
            {
                Console.Write("숫자를 입력하세요: ");
                string userInput = Console.ReadLine();

                int userGuess;
                if (int.TryParse(userInput, out userGuess))
                {
                    numberOfTries++;

                    if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("너무 큽니다!");
                    }
                    else if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("너무 작습니다!");
                    }
                    else
                    {
                        Console.WriteLine("축하합니다! {0}번 만에 숫자를 맞추었습니다.", numberOfTries);
                        isNumberGuessed = true;
                    }
                }
                else
                {
                    Console.WriteLine("유효한 숫자가 아닙니다. 다시 시도해주세요.");
                }
            }
        }
    }
}
