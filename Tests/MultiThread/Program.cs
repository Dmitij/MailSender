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
        
        
        static void Task6()
        {
            Console.Clear();

            int N = 10; // размерность массива
            int[,] A = new int[N, N];
            int[,] B = new int[N, N];
            int[,] C = new int[N, N];
            
            

            Random rnd1 = new Random();
            Random rnd2 = new Random();

            for (int i = 0; i < N; i++)   //заполняем массивы А и В
            {
                for (int j = 0; j < N; j++)
                {
                    A[i, j] = rnd1.Next(0, 10);
                    B[i, j] = rnd2.Next(0, 10);
                }
            }
            
            //MatrixPrint(A);
            Console.Write("Обычный цикл \n");
            //MatrixPrint(B);

            TimeChecker(A, B, C, N);



            //for (int i = 0; i < N; ++i)
            //    for (int j = 0; j < N; ++j)
            //    {
            //        var tskSum = Task.Factory.StartNew(() => Sum(i, j));
            //        Task.WaitAll(tskSum);
            //        //Parallel.Invoke(() => Sum(i, j));
            //    }
            //Parallel.For(0, N, ccc);


            C = new int[N, N];
            Task[] tasks;

            int TaskCount = 4;   //количество процессов
            int interval;         //количество вычеслений на один процесс


            for (int i = 0; i < TaskCount; i++)
            {
                if (N % (i + 1) == 0)
                    interval = N / (i + 1);
                else
                    interval = (N - (N % (i + 1))) / (i + 1);
                tasks = new Task[i + 1];
                for (int j = 0; j < tasks.Length; j++)
                {
                    int t1 = j;
                    int t2 = j + 1;
                    tasks[j] = new Task(() => Mult(A, B, C, N, t1 * interval, t2 * interval));
                 }
                C = new int[N, N];
                TimeChecker2(C, N, tasks);
                
            }
            

            //Task[] tasks2 = new Task[3];
            //int j = 1;
            //for (int i = 0; i < tasks2.Length; i++)
            //    tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task {j++}"));

            //Task[] tasks = new Task[4]
            //{
            //       new Task(() => Mult(A,B,C,N,0,N/5)),
            //       new Task(() => Mult(A,B,C,N,N/5,N/4)),
            //       new Task(() => Mult(A,B,C,N,N/4,N/2)),
            //       new Task(() => Mult(A,B,C,N,N/2,N))
            //};


            //TimeChecker2(A, B, C, N, 0, N, tasks);


            Console.ReadLine();
            Menu();
        }
        
        static void TimeChecker(int[,] A, int[,] B, int[,] C, int N)
        {
            Stopwatch stopWatch = new Stopwatch();// Запускаем внутренний таймер объекта Stopwatch
            stopWatch.Start();

            Mult(A, B, C, N, 0, N);

            stopWatch.Stop();

            //Console.Write("{0,28:0}", "=\n");
            MatrixPrint(C,N); 

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("Потрачено на выполнение: " + elapsedTime);
            Console.WriteLine("Потрачено тактов на выполнение: " + stopWatch.ElapsedTicks);
        }

        static void TimeChecker2( int[,] C, int N,  Task[] tasks)
        {
            Stopwatch stopWatch = new Stopwatch();// Запускаем внутренний таймер объекта Stopwatch
            stopWatch.Start();            

            foreach (var t in tasks)
                t.Start();
            Task.WaitAll(tasks); // ожидаем завершения задач 

            stopWatch.Stop();

            //Console.Write("{0,28:0}", "=\n");
            MatrixPrint(C,N); 

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("Потрачено на выполнение: " + elapsedTime);
            Console.WriteLine("Потрачено тактов на выполнение: " + stopWatch.ElapsedTicks);
        }

        static void Mult(int[,] A, int[,] B, int[,] C, int N, int t1, int t2)
        {
            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                    for (int k = t1; k < t2; ++k)
                        C[i, j] += A[i, k] * B[k, j];
        }

       


        //static void Sum( int i, int j)
        //{            
        //    for (int k = 0; k < N; ++k)
        //        D[i, j] += A[i, k] * B[k, j];            
        //}



        static void MatrixPrint(int[,] arr,int N)
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
