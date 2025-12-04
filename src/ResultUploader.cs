using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JsonResultUploadDemo
{
    public class ResultUploader
    {
        private readonly string _url;
        private readonly HttpClient _client = new HttpClient();

        public ResultUploader(string url)
        {
            _url = url;
        }

        public bool Upload(string json)
        {
            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine($"[CLIENT] POST to {_url}");
                var resp = _client.PostAsync(_url, content).Result;

                Console.WriteLine($"[CLIENT] HTTP Status: {(int)resp.StatusCode} {resp.StatusCode}");

                string respText = resp.Content.ReadAsStringAsync().Result;
                Console.WriteLine("[CLIENT] Response body:");
                Console.WriteLine(respText);

                return resp.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CLIENT] Upload failed: {ex.Message}");
                return false;
            }
        }
    }
}