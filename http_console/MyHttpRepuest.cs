using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace http_console
{
    class MyHttpRepuest
    {

        public String URL { get; private set; }
        public String Base64Credential { get; set; }
        public HttpMethod HttpSendMethod { get; set; }

        private static HttpClient httpClient = new HttpClient();


        public async Task<String> InputInfomation(String mode)
        {

            Console.WriteLine("URLを入力");
            URL = Console.ReadLine();

            Console.WriteLine("Basic認証用IDを入力");
            var ID = Console.ReadLine();

            Console.WriteLine("Basic認証用Passwordを入力");
            var Password = Console.ReadLine();

            Base64Credential = Convert.ToBase64String(Encoding.UTF8.GetBytes(ID + ":" + Password));

            switch (mode)
            {
                case "0":
                    // Get
                    HttpSendMethod = HttpMethod.Get;
                    break;
                case "1":
                    // Post
                    HttpSendMethod = HttpMethod.Post;
                    break;
                default:
                    // 0でも1でもない場合はエラーで処理おわり
                    Console.WriteLine("ちゃんと値をいれよう");
                    break;
            }

            var result = await GetMsgTaskAsync();
            return result;


        }

        private async Task<String> GetMsgTaskAsync()
        {
            var msg = await PostHttpAsync();
            var result = await msg.Content.ReadAsStringAsync();

            return result;

        }

        private async Task<HttpResponseMessage> PostHttpAsync()
        {
            var httpRequest = new HttpRequestMessage(HttpSendMethod, URL);
            httpRequest.Headers.Add(@"Authorization", @"Basic " + Base64Credential);


            var sendInfoResult = await httpClient.SendAsync(httpRequest);
            if (sendInfoResult.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("おめでとうございます。ステータスコード" + (int)sendInfoResult.StatusCode + "でした～");
            }
            else
            {
                Console.WriteLine($@"
やあ （´・ω・｀)
ようこそ、バーボンハウスへ。
このテキーラはサービスだから、まず飲んで落ち着いて欲しい。

うん、「また」なんだ。済まない。
仏の顔もって言うしね、謝って許してもらおうとも思っていない。

でも、このステータスコード{(int)sendInfoResult.StatusCode}を見たとき、君は、きっと言葉では言い表せない
「ときめき」みたいなものを感じてくれたと思う。
殺伐とした世の中で、そういう気持ちを忘れないで欲しい
そう思って、このスレを立てたんだ。

じゃあ、注文を聞こうか。
                ");
            }

            return sendInfoResult;
        }

    }
}
