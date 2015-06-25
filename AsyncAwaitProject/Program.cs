using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitConsole
{
    class Program
    {
        //Observera att Task-metoden SlowOperationAsync enligt definitionen ska returnera Task<int> men
        //returnerar 42 precis som den vanliga SlowOperation-metoden.
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to start Slow Operation without Async and Await.");
            Console.WriteLine("Press 2 to start Slow Operation with Async and Await.");
            Console.WriteLine("Press 3 to start Web Access Operation with Async and Await.");
            Console.WriteLine("Press 4 to start operations 2 and 3.");
            var tangentTryck = Console.ReadKey();
            if (tangentTryck.Key == ConsoleKey.D1)
                OperationWithoutAsyncAndAwait();
            else if (tangentTryck.Key == ConsoleKey.D2)
                OperationWithAsyncAndAwait();
            else if (tangentTryck.Key == ConsoleKey.D3)
                AccessTheWeb();
            else if (tangentTryck.Key == ConsoleKey.D4)
                CombinedOperations();
            else 
                Console.WriteLine("Illegal choice");

        }
        static void OperationWithoutAsyncAndAwait()
        {
            Console.WriteLine("This is Slow Operation without async and await");
            var task = Task.Factory.StartNew<int>(SlowOperation);
            PrintSomeNumbers();
            Console.WriteLine("Slow Operation Result: {0}", task.Result);
            Console.WriteLine("Main completed on {0}", Thread.CurrentThread.ManagedThreadId);
        }
        static void OperationWithAsyncAndAwait()
        {
            Console.WriteLine("This is Slow Operation with async and await");
            var task = SlowOperationAsync();
            PrintSomeNumbers();
            Console.WriteLine("Slow Operation Result: {0}", task.Result);
            Console.WriteLine("Main completed on {0}", Thread.CurrentThread.ManagedThreadId);
        }
        static void AccessTheWeb()
        {
            Console.WriteLine("This is AccessTheWeb");
            var task = AccessTheWebAsync();
            PrintSomeNumbers();
            Console.WriteLine("Web Access Result: {0}", task.Result);
            Console.WriteLine("Main completed on {0}", Thread.CurrentThread.ManagedThreadId);
        }
        static void CombinedOperations()
        {
            Console.WriteLine("This is AccessTheWeb");
            var task3 = AccessTheWebAsync();
            var task2 = SlowOperationAsync();
            Task.WhenAll(task2, task3);
            PrintSomeNumbers();
            Console.WriteLine("Slow Operation Result: {0}", task2.Result);
            Console.WriteLine("Web Access Result: {0}", task3.Result);
            Console.WriteLine("Main completed on {0}", Thread.CurrentThread.ManagedThreadId);
        }
        static void PrintSomeNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
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
        static async Task<int> AccessTheWebAsync()
        {
            Console.WriteLine("Access the Web started on {0}", Thread.CurrentThread.ManagedThreadId);
            // You need to add a reference to System.Net.Http to declare client.
            HttpClient client = new HttpClient();

            // GetStringAsync returns a Task<string>. That means that when you await the 
            // task you'll get a string (urlContents).
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            // You can do work here that doesn't rely on the string from GetStringAsync.
            //DoIndependentWork();

            // The await operator suspends AccessTheWebAsync. 
            //  - AccessTheWebAsync can't continue until getStringTask is complete. 
            //  - Meanwhile, control returns to the caller of AccessTheWebAsync. 
            //  - Control resumes here when getStringTask is complete.  
            //  - The await operator then retrieves the string result from getStringTask. 
            string urlContents = await getStringTask;
            Console.WriteLine("Access the Web ended on {0}", Thread.CurrentThread.ManagedThreadId);

            // The return statement specifies an integer result. 
            // Any methods that are awaiting AccessTheWebAsync retrieve the length value. 
            return urlContents.Length;
        }
    }
}
