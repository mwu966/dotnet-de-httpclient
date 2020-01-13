using System;
using System.Net.Http;
using System.Text;

namespace http_console
{
    class Program
    {
       private static HttpClient httpClient = new HttpClient();
        static async void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string pass = "";
            string id = "";

            string base64str = Convert.ToBase64String(Encoding.UTF8.GetBytes(id + ":" + pass));

            var content = new StringContent("");

            content.Headers.Add(@"Authorization", @"Basic "+ base64str);


            var postTest = await httpClient.PostAsync(@"test",content);

            var getTest = await httpClient.GetAsync(@"test");            

        }


    }
}
