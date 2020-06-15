using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WireSharp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Task adminHostTask = Task.Run(() => CreateWebHostBuilder(args).Build().Run());
            Task reverseProxyHostTask = Task.Run(() => CreateReverseProxyHostBuilder(args).Build().Run());
            await Task.WhenAll(new Task[] { adminHostTask, reverseProxyHostTask });
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static IWebHostBuilder CreateReverseProxyHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://localhost:8890;http://localhost:8889")
                .UseStartup<ReverseProxyStartup>();
    }
}
