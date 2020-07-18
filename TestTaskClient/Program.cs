using System;
using System.Threading.Tasks;
using System.Timers;
using RestSharp;
using RestSharp.Authenticators;

namespace TestTaskClient
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private async static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
            await sendDataAsync();
        }
        private async static Task sendDataAsync()
        {
            try
            {
                //https://restsharp.dev/getting-started/getting-started.html#asynchronous-calls

                var client = new RestClient("https://localhost:44349/api/");
                var request = new RestRequest("RegistrationInfo")
                    .AddJsonBody(new InfoRequest()
                    {
                        ComputerName = "fsfs",
                        DiskCFreeSpace = 123
                    }); ;
                var response = await client.PostAsync<Info>(request);
                Console.WriteLine("send {0}", response.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception: {0}", ex.Message);
            }
            
            
        }

    }
}
