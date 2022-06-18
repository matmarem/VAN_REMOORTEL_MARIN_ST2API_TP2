using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATAFEED_WEATHER;
public class Program
{
    public static async Task Main(string[] args)
    {
        Root ff = new Root();
        Root ff2 = new Root();
        Root ff3 = new Root();
        Root Tokyo = new Root();
        Root NY = new Root();
        Root Paris = new Root();
        Root Kiev = new Root();
        Root Berlin = new Root();
        Root Moscow = new Root();
        var weather = new WeatherApp();
        //Console.WriteLine("Rentre la latitude : ");
        //double latitude = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine("Rentre la longitude : ");
        //double longitude = Convert.ToDouble(Console.ReadLine());
        
        var coord = new Coordinates(31.791702, -7.09262);
        ff = await weather.GetWeather(coord);
        Console.WriteLine("Temperature ressenti au maroc : {0} ",(ff.current.feels_like)-(272.15) );
        
        var coord2 = new Coordinates(59.911491, 10.757933);
        ff2 = await weather.GetWeather(coord2);
        System.DateTime Sunrise = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
        Sunrise = Sunrise.AddSeconds( ff2.current.sunrise ).ToLocalTime();
        System.DateTime Sunset = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
        Sunset = Sunset.AddSeconds( ff2.current.sunset ).ToLocalTime();
        Console.WriteLine("A Oslo, le soleil se couche : {0} et se leve : {1}",Sunset, Sunrise );
        
        var coord3 = new Coordinates(-6.2146200, 106.8451300);
        ff3 = await weather.GetWeather(coord3);
        Console.WriteLine("Temperature à Jakarta : {0} ",(ff3.current.temp)-(272.15) );
        
        var tokyo = new Coordinates(35.6894, 139.692);
        var nY = new Coordinates(	40.712784, -74.005941);
        var paris = new Coordinates(48.856614, 2.3522219);
        Tokyo = await weather.GetWeather(tokyo);
        NY = await weather.GetWeather(nY);
        Paris = await weather.GetWeather(paris);
        double[] numbers = { Tokyo.current.wind_speed, NY.current.wind_speed, Paris.current.wind_speed };
        double biggestNumber = numbers.Max();
        if (biggestNumber == Tokyo.current.wind_speed)
        {
            Console.WriteLine("il y a plus de vent à Tokyo");
        }
        else if (biggestNumber == NY.current.wind_speed)
        {
            Console.WriteLine("il y a plus de vent à New-York");
        }
        else
        {
            Console.WriteLine("il y a plus de vent à Paris");
        }
        
        var berlin = new Coordinates(	52.520007, 13.404954);
        var kiev = new Coordinates(	50.4501, 30.5234);
        var moscow = new Coordinates(55.755826, 37.6173);
        Berlin = await weather.GetWeather(berlin);
        Kiev = await weather.GetWeather(kiev);
        Moscow = await weather.GetWeather(moscow);
        Console.WriteLine("A Berlin, humidité : {0} et pression : {1}",Berlin.current.humidity, Berlin.current.pressure );
        Console.WriteLine("A Kiev, humidité : {0} et pression : {1}",Kiev.current.humidity, Kiev.current.pressure );
        Console.WriteLine("A Moscow, humidité : {0} et pression : {1}",Moscow.current.humidity, Moscow.current.pressure );
        
    }
}