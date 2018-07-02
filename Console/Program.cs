using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting 30 seconds for APi to start");
            Thread.Sleep(30000);
            CallApi();
        }
        static async void CallApi()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = config.Build();
            var url = configuration["APIUrl"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
              HttpResponseMessage response = client.GetAsync("/api/message/" + "0").Result;

              if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (HttpContent content = response.Content)
                    {
                        string _response = await response.Content.ReadAsStringAsync();

                        var messages = JsonConvert.DeserializeObject<List<MessageDto>>(_response);
                        foreach (var msg in messages)
                        {
                            Console.WriteLine("{0}", msg.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("unable to retreive information, please check the log files");
                }
                    

                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue.......");
                    Console.ReadKey();

                }

            }
        }
    
}
