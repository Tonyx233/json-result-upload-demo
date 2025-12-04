using System;
using System.IO;
using System.Threading;

namespace JsonResultUploadDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== JSON Result Upload Demo ===");
            Console.WriteLine("Starting SERVER + CLIENT ...");

            // 1️ Start server
            var server = new ResultServer();
            server.Start(5000);
            Console.WriteLine("[MAIN] Server started.");

            Thread.Sleep(1000);

            // 2️ Read json file
            string jsonPath = Path.Combine(AppContext.BaseDirectory, "sample-result.json");
            if (!File.Exists(jsonPath))
            {
                Console.WriteLine($"[ERROR] Cannot find file: {jsonPath}");
                return;
            }
            string json = File.ReadAllText(jsonPath);

            // 3️ Start client and send JSON
            var client = new ResultUploader("http://localhost:5000/upload");
            bool ok = client.Upload(json);

            Console.WriteLine(ok ? "[MAIN] Upload success." : "[MAIN] Upload failed.");

            Console.WriteLine("\nPress ENTER to stop server...");
            Console.ReadLine();

            // 4️ Stop server
            server.Stop();
            Console.WriteLine("[MAIN] Shutdown complete.");
        }
    }
}
