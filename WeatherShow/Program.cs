using Newtonsoft.Json;
using System.Net;

class Program
{

    static void Main(string[] args)
    {

        string city;
        Console.WriteLine("Please enter the name of the city where you want to know the temperature: ");
        city = Console.ReadLine();

        
        string url = "http://api.weatherapi.com/v1/current.json?key=dafc3221345b40c6803133544220608&q=" + city + "&aqi=no";


        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        string response;


        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
        {
            response = streamReader.ReadToEnd();
            //System.Console.WriteLine(response);
        }

        WeatherShow.WeatherResponseApp weatherConsoleApp = JsonConvert.DeserializeObject<WeatherShow.WeatherResponseApp>(response);

        Console.WriteLine("Temperature in {0}, {1} °C ", weatherConsoleApp.location.name, weatherConsoleApp.current.temp_c);
        Console.ReadLine();

    }
}