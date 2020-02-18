using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class Program
    {
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("5 - Task 5");
            Console.WriteLine("6 - Task 6");


            Console.WriteLine("AnyKey - Exit");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D5:
                    Task5();
                    break;
                case ConsoleKey.D6:
                    Task6();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.Escape:
                    Console.WriteLine("Bye-bye");
                    return;
                default:
                    break;
            }
        }
        static void Factorial(object n)
        {
            double N = Convert.ToInt64(n);
            if (N < 0)
                throw new ArgumentException("Значение не должно быть отрицательным");
            double fac = 1;
            while (N > 1)
            {
                Console.WriteLine("Считаю факториал");
                fac *= N;
                N--;
                Thread.Sleep(300);
            }
            Console.WriteLine("Факториал: " + fac);
        }
        static void Sum(object n)
        {
            int sum = 0;
            double N = Convert.ToInt64(n);
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine("Считаю сумму");
                sum += i;
                Thread.Sleep(300);
            }
            Console.WriteLine("Сумма: " + sum);
        }

        static void Task5() //считаем паралельно в двух потоках факториал и сумму
        {
            Console.Clear();
            Console.WriteLine("Введите N: ");
            int n = int.Parse(Console.ReadLine());
            // создаем новый поток
            Thread myThread1 = new Thread(new ParameterizedThreadStart(Factorial));
            myThread1.Start(n);
            Thread myThread2 = new Thread(new ParameterizedThreadStart(Sum));
            myThread2.Start(n);
            Console.ReadLine();
        }
        static void Task6()
        {
            Console.Clear();


            int N = 100; // размерность массива
            int[,] arr1 = new int[N, N];
            int[,] arr2 = new int[N, N];


            Console.ReadLine();

        }
        static void Main(string[] args)
        {
            Menu();   
        }

    }
}
