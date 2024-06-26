﻿using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SeckillPro.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new WebHostBuilder()
               .UseKestrel();
            //参数指定端口
            builder = args.Length > 0 ? builder.UseUrls(args[0]) : builder;
            var host = builder.UseContentRoot(Directory.GetCurrentDirectory())
                  .UseIISIntegration()
                  .UseStartup<Startup>()
                  .Build();
            host.Run();
        }
    }
}