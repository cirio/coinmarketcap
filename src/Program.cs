using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;

namespace coinmarketcap
{
    class Program
    {
        private static Timer ticker;
        public static IConfiguration Configuration { get; set; }

        

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            Console.WriteLine("********* web api Coinmarketcap started ********* ");
            
            ticker = new Timer(TimerMethodAsync, null, Convert.ToInt32(Configuration["timerStartsAfter"]),
            Convert.ToInt32(Configuration["runProcessEvery"]));

            Console.WriteLine("Press the Enter key to end the program.");
            Console.ReadLine();
        }


        //Process method
        public static async void TimerMethodAsync(object state)
        {
            await ProcessTickerSpecificCurrency();
        }

        
        #region Web API Call
        
        private static async Task ProcessTickerSpecificCurrency()
        {
            //Define http client
            HttpClient client = new HttpClient();
            
            
            //Define headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            //Instance new serializer
            var serializer = new DataContractJsonSerializer(typeof(List<TickerSpecificCurrency>));
            
            //Get API result
            var streamTask = client.GetStreamAsync($"{Configuration["processTickerSpecificCurrencyURL"]}");
            
            //Serialize to object
            List<TickerSpecificCurrency> lst = serializer.ReadObject(await streamTask) as List<TickerSpecificCurrency>;
            
            //Set date read
            lst.ForEach(x => x.DateRead = DateTime.Now);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),$"{Configuration["filePathprocessTickerSpecificCurrency"]}");

            //Append in file
            if(System.IO.File.Exists(filePath)){
                using (TextWriter writer = File.AppendText(filePath))
                {
                    var csv = new CsvWriter(writer, new CsvConfiguration { HasHeaderRecord = false } );
                    csv.WriteRecords(lst);
                }
            }
            else{ //Write a new file
                using (TextWriter writer = File.CreateText(filePath))
                {
                    var csv = new CsvWriter(writer, new CsvConfiguration { HasHeaderRecord = true } );
                    csv.WriteRecords(lst);
                }
            }
            
            Console.WriteLine($"Records added > {DateTime.Now}");
            
        }
        #endregion
        
        
    }
}
