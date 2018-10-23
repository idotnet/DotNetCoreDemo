using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Web.Services;
using DotNetCore.Web.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNetCore.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //每当有 其他的类 来请求 ICinemaService的时候，容器都会返回 CinemaMemoryService的实例
            services.AddSingleton<ICinemaService, CinemaMemoryService>();
            services.AddSingleton<IMovieService, MovieMemoryService>();

            services.Configure<ConnectionOptions>(_configuration.GetSection("ConnectionStrings"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            //Configure里面中间件的顺序和重要

            if (env.IsDevelopment())
            {
                //判断自定义环境变量用env.IsEnvironment("");

                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }

            app.UseForwardedHeaders()
            #region 测试数据
            //Run会直接返回 不执行后面的中间件，想继续执行得用 Use
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("Hello World!11111开始~~~~~");
            //    await context.Response.WriteAsync("Hello World!11111");
            //    await next();
            //    logger.LogInformation("Hello World!11111结束~~~~~~");
            //});

            //app.Run(async (context) =>
            //{
            //    logger.LogInformation("Hello World!2222222开始~~~~~");
            //    await context.Response.WriteAsync("Hello World!222222");
            //    logger.LogInformation("Hello World!2222222结束~~~~~");
            //});
            #endregion

            app.UseStatusCodePages();//将错误状态码直接显示到页面上
            //app.UseStatusCodePagesWithRedirects();//可以跳转到自定义的错误页

            app.UseStaticFiles();//添加了才能访问到wwwroot下的静态文件

            //身份认证放在MVC之前

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{Id?}");
            });
        }
    }
}
