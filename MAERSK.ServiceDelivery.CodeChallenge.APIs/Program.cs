// This code is private to MAERSK
// Copyright 2022

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
