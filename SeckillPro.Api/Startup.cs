using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace SeckillPro.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddControllers(o =>
            {
                //通过修改配置移除默认的null值格式化器(为了兼容以前的老代码)
                o.OutputFormatters.RemoveType(typeof(HttpNoContentOutputFormatter));
                o.OutputFormatters.Insert(0, new HttpNoContentOutputFormatter
                {
                    TreatNullValueAsNoContent = false
                });
            }).ConfigureApiBehaviorOptions(options =>
            {
                //禁用自动 400 响应
                options.SuppressModelStateInvalidFilter = true;
            }).AddJsonOptions(config =>
            {
                //swagger注释实体字段不使用驼峰样式
                config.JsonSerializerOptions.PropertyNamingPolicy = null;
                config.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}