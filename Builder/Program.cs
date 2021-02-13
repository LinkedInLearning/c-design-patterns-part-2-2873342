using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var uriBuilder = new UriBuilder("https://linkedin.com/learning");
            Console.WriteLine(uriBuilder.Host);
            Console.WriteLine(uriBuilder.Path);
            Console.WriteLine(uriBuilder.Port);

            var client = new HttpClient();
            var resp = await client.GetAsync(uriBuilder.Uri);

            Console.WriteLine(resp.StatusCode);

            uriBuilder.Path =  "/learning/blazor-getting-started";
            resp = await client.GetAsync(uriBuilder.Uri);

            Console.WriteLine(resp.StatusCode);
        }
    }
}
