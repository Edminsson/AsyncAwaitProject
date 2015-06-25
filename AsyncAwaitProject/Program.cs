using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to start Slow Operation without Async and Await.");
            Console.WriteLine("Press 2 to start Slow Operation with Async and Await.");
            var tangentTryck = Console.ReadKey();
            if (tangentTryck.Key == ConsoleKey.D1)
                OperationWithoutAsyncAndAwait();
            else
                OperationWithAsyncAndAwait();
        }
        static void OperationWithoutAsyncAndAwait()
        {
            Console.WriteLine("This is Slow Operation without async and await");
            var task = Task.Factory.StartNew<int>(SlowOperation);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Slow Operation Result: {0}", task.Result);
            Console.WriteLine("Main completed on {0}", Thread.CurrentThread.ManagedThreadId);
        }
        static void OperationWithAsyncAndAwait()
        {
            Console.WriteLine("This is Slow Operation with async and await");
            var task = SlowOperationAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Slow Operation Result: {0}", task.Result);
            Console.WriteLine("Main completed on {0}", Thread.CurrentThread.ManagedThreadId);
        }
        static int SlowOperation()
        {
            Console.WriteLine("Slow Operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("Slow Operation ended on {0}", Thread.CurrentThread.ManagedThreadId);
            return 42;
        }
        static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine("Slow Operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            Console.WriteLine("Slow Operation ended on {0}", Thread.CurrentThread.ManagedThreadId);
            return 42;
        }
    }
}
