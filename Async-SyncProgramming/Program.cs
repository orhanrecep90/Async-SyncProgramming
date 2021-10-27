using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Async_SyncProgramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("AsyncMethod running");
            var task5 = AsyncMethod(5000);
            var task6 = AsyncMethod(6000);
            var task7 = AsyncMethod(7000);
            var resultTask = Task.WhenAll(task5, task6, task7);
            //Senkron metod
            SyncMethod(7000);
            await resultTask;
            watch.Stop();
            Console.WriteLine("AsyncMethod Total Time:" + watch.ElapsedMilliseconds);
            Console.WriteLine("For starting sync methods press a key.");
            Console.ReadLine();

            watch.Start();
            Console.WriteLine("SyncMethod running");
            SyncMethod(5000);
            SyncMethod(6000);
            SyncMethod(7000);
            watch.Stop();
            Console.WriteLine("SyncMethod Total Time:" + watch.ElapsedMilliseconds);
            Console.WriteLine();

        }
        public static async Task AsyncMethod(int delayTime)
        {
            Console.WriteLine("AsyncMethod : " + delayTime + " : Start");
            await Task.Delay(delayTime);
            Console.WriteLine("AsyncMethod : " + delayTime + " : End");
        }

        public static void SyncMethod(int delayTime)
        {
            Console.WriteLine("SyncMethod : " + delayTime + " : Start");
            Thread.Sleep(delayTime);
            Console.WriteLine("SyncMethod : " + delayTime + " : End");
        }
    }
}
