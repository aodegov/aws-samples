using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace VehicleHub.TokenRequest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "<your oauth2/token url>";

            var httpRequest = WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Headers["Authorization"] = "Basic <your token>";
            httpRequest.Headers["Content-Length"] = "0";

            var httpResponse = await httpRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();
                Console.WriteLine(result);
            }
        }
    }
}
