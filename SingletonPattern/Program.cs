using System;
using System.Threading.Tasks;
using SingletonLoggerLib;

namespace SingletonPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = Logger.GetLoggerInstance();
            Logger logger2 = Logger.GetLoggerInstance();
            Logger logger3 = Logger.GetLoggerInstance();

            Task[] tasks = new Task[]
            {
            Task.Factory.StartNew(()=>
                                logger.LogMessage("This is Singleton Pattern implementation in Logging helper library", LogLevel.INFO) ),

            Task.Factory.StartNew(() =>
                                logger2.LogMessage("This is Singleton Pattern implementation in Logging helper library", LogLevel.WARNING)),

            Task.Factory.StartNew(() =>
                                logger3.LogMessage("This is Singleton Pattern implementation in Logging helper library", LogLevel.ERROR))
            };

            //Block until all tasks complete.
            Task.WaitAll(tasks);


            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
