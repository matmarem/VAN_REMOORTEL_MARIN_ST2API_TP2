using System.Data;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace DATAFEED_WEATHER
{
    public class WeatherApp
    {
        private HttpClient HttpClient { get; set; }
        private const string API_key = "bbe8fe51aa7d630332569e6f1e92fb77";

        public WeatherApp()
        {
            HttpClient = new HttpClient();
        }

        public async Task<Root> GetWeather(Coordinates coord)
        {
            Root obj = new Root();
            var uri = Build(coord.lat, coord.lon);
            obj = await Connect(uri);
            return obj;
        }

        private static Uri Build(double Latitude, double Longitude)
        {
            string Path = $"https://api.openweathermap.org/data/2.5/onecall?lat={Latitude}&lon={Longitude}&appid={API_key}";
            Uri uri = new Uri(Path);
            return uri;
        }


        private async Task<Root> Connect(Uri uri)
        {
            Root rootObj = new Root();
            try
            {
                String ResponseBody = await HttpClient.GetStringAsync(uri);
                //Console.WriteLine(ResponseBody);
                rootObj = JsonConvert.DeserializeObject<Root>(ResponseBody);
                //Console.WriteLine(rootObj);
            }
            catch(Exception e)
            {
                Console.WriteLine("\nException!");
                Console.WriteLine("Message: {0} ", e.Message);
            }
            return rootObj;
        }
    }
}