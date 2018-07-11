using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Crashy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet("health", context =>
            {
                return context.Response.WriteAsync("");
            });            

            var routes = routeBuilder.Build();
            app.UseRouter(routes);

            // Default if no routes match
            app.Run(async (context) =>
            {
                Random rnd = new Random();
                try {
                    int danger = 1 / rnd.Next(0, 2);
                } catch (System.DivideByZeroException) {
                    // explicity terminate because otherwise kestrel will catch this exception and recover
                    Environment.Exit(1);
                }
                
                context.Response.OnStarting((state) =>
                {
                    context.Response.ContentType = "text/plain; charset=UTF-8";
                    return Task.FromResult(0);
                }, null);

                await context.Response.WriteAsync("Hello I am a little unstable 🤪");
            });
        }
    }
}
