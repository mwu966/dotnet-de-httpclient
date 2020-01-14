using System;

namespace http_console
{
    class Program
    {

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Get or Post? ※Getは0､Postは1を入力");
            var clientMode = Console.ReadLine();

            var myHttpRepuest = new MyHttpRepuest();
            var inputInfo = await myHttpRepuest.InputInfomation(clientMode);
            Console.WriteLine(inputInfo);

            // Get or Post?
            // URL
            // ID
            // Pass
            // Postの場合JSON

        }


    }
}
