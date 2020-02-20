using System;
using System.Diagnostics;
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
            Menu();
        }

        public static int N = 1000; // размерность массива
        public static int[,] A = new int[N, N];
        public static int[,] B = new int[N, N];
        public static int[,] C = new int[N, N];
        public static int[,] D = new int[N, N];
        static void Task6()
        {
            Console.Clear();


            

            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    A[i, j] = rnd1.Next(0, 10);
                    B[i, j] = rnd2.Next(0, 10);
                }
            }

            //MatrixPrint(A);
            Console.Write("{0,28:0}", "x\n");
            //MatrixPrint(B);

            // Запускаем внутренний таймер объекта Stopwatch
            long ellapledTime1 = DateTime.Now.Millisecond;
            stopwatch1.Start();
            
            
            

            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                    for (int k = 0; k < N; ++k)
                        C[i, j] += A[i, k] * B[k, j]; //Собираем сумму произведений
                       
            
            Console.Write("{0,28:0}", "=\n");
            //MatrixPrint(C);

            
            stopwatch1.Stop();
            Console.WriteLine("Потрачено тактов на выполнение: " + stopwatch1.ElapsedTicks);
            ellapledTime1 = DateTime.Now.Millisecond - ellapledTime1;
            Console.WriteLine("Потрачено милисекунд на выполнение: " + ellapledTime1);

            long ellapledTime2 = DateTime.Now.Millisecond;
            stopwatch2.Start();

            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                {
                    var tskSum = Task.Factory.StartNew(() => Sum(i, j));
                    Task.WaitAll(tskSum);
                    //Parallel.Invoke(() => Sum(i, j));
                }

            //Parallel.For(0, N, ccc);

            Console.Write("{0,28:0}", "=\n");
            //MatrixPrint(D);
            
            stopwatch2.Stop();
            Console.WriteLine("Потрачено тактов на выполнение: " + stopwatch2.ElapsedTicks);
            ellapledTime2 = DateTime.Now.Millisecond - ellapledTime2;
            Console.WriteLine("Потрачено милисекунд на выполнение: " + ellapledTime2);


            Console.ReadLine();
            Menu();
        }
        static void ccc(int i)
        {     
            
                for (int j = 0; j < N; ++j)
                    for (int k = 0; k < N; ++k)
                        D[i, j] += A[i, k] * B[k, j]; //Собираем сумму произведений
        }



        static void Sum( int i, int j)
        {            
            for (int k = 0; k < N; ++k)
                D[i, j] += A[i, k] * B[k, j];            
        }



        static void MatrixPrint(int[,] arr)
        {      
            for (int i = 0; i < N; i++)
            {
                Console.Write("|");
                for (int j = 0; j < N; j++)                                    
                    Console.Write("{0,4:0} ", arr[i, j]);
                
                Console.Write("|" );
                Console.WriteLine();                
            }            
        }
        
        static void Main(string[] args)
        {
            Menu();   
        }

    }
}
