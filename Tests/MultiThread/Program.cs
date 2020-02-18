using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class Program
    {
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
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N: ");
            int n = int.Parse(Console.ReadLine());
            // создаем новый поток
            Thread myThread1 = new Thread(new ParameterizedThreadStart(Factorial));
            myThread1.Start(n);
            Thread myThread2 = new Thread(new ParameterizedThreadStart(Sum));
            myThread2.Start(n);   
            Console.ReadLine();



        }

       
    }
}
