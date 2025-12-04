using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JsonResultUploadDemo
{
    public class ResultServer
    {
        private HttpListener _listener;
        private bool _running = false;

        public void Start(int port)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://+:{port}/upload/");
            _listener.Start();
            _running = true;

            Console.WriteLine($"[SERVER] server started on http://localhost:{port}/upload");

            Task.Run(ListenLoop);
        }

        private async Task ListenLoop()
        {
            while (_running)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    var req = context.Request;
                    var resp = context.Response;

                    if (req.HttpMethod != "POST")
                    {
                        resp.StatusCode = 405;
                        resp.Close();
                        continue;
                    }

                    using var reader = new System.IO.StreamReader(req.InputStream, req.ContentEncoding);
                    string body = await reader.ReadToEndAsync();

                    Console.WriteLine("=== [SERVER] Received JSON ===");
                    Console.WriteLine(body);
                    Console.WriteLine("================================");

                    string respJson = "{\"status\":\"OK\",\"message\":\"Result received\"}";
                    byte[] data = Encoding.UTF8.GetBytes(respJson);
                    resp.StatusCode = 200;
                    resp.ContentType = "application/json";
                    resp.OutputStream.Write(data, 0, data.Length);
                    resp.Close();
                }
                catch (HttpListenerException)
                {
                    if (!_running) return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SERVER] Error: {ex.Message}");
                }
            }
        }

        public void Stop()
        {
            Console.WriteLine("[SERVER] Stopping server...");
            _running = false;
            try
            {
                _listener?.Stop();
            }
            catch { }
        }
    }
}