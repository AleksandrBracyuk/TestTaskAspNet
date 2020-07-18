using System;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using RestSharp;
using RestSharp.Authenticators;
using TestTaskClient.Model;

namespace TestTaskClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            sender.Start();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            sender.Stop();
        }
    
    }
}
