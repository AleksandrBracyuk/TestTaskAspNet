using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RestSharp;
using RestSharp.Authenticators;
using TestTaskClient.Model;

namespace TestTaskClient
{
    public class Sender
    {
        const int timerFrequency = 30000;
        const string driverCName = "C:\\";
        const string serverAddress = "https://localhost:44349/api/";

        private System.Timers.Timer timer;

        public void Start()
        {
            timer = new System.Timers.Timer(timerFrequency);
            timer.Elapsed += TimerTickAsync;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Stop();
            timer.Dispose();
        }


        private async void TimerTickAsync(object sender, ElapsedEventArgs e)
        {
            try
            {
                Console.WriteLine("timer start at {0:HH:mm:ss.fff}", e.SignalTime);
                await sendDataAsync(Environment.MachineName, this.GetDriverCFreeSpace());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"exception: {ex.Message}");
            }
        }

        private decimal GetDriverCFreeSpace()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.Name == driverCName)
                {
                    return 1m * d.TotalFreeSpace / (1024 * 1024);
                }
            }
            throw new Exception("Driver C not found.");
        }

        private async static Task sendDataAsync(string machineName, decimal freeSpace)
        {
            try
            {
                //https://restsharp.dev/getting-started/getting-started.html#asynchronous-calls
                var client = new RestClient(serverAddress);
                var request = new RestRequest("RegistrationInfo")
                    .AddJsonBody(new InfoRequest()
                    {
                        ComputerName = machineName,
                        DiskCFreeSpace = freeSpace
                    }); ;
                var response = await client.PostAsync<Info>(request);
                Console.WriteLine($"send {response.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Send data exception: {ex.Message}");
            }


        }

    }
}
