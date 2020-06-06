using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RecipeWebApplication1.GraphQL;
using RecipeWebApplication1.Repositories;

namespace RecipeWebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Scoped 1 - Specifies that a new instance of the service will be created for each scope (a new scope is created for each request).
            // Singleton 0 - Specifies that a single instance of the service will be created.
            // Transient 2 - Specifies that a new instance of the service will be created every time it is requested.

            // workaround for System.InvalidOperationException: Synchronous operations are disallowed. Call ReadAsync or set AllowSynchronousIO to true instead.
            // at Microsoft.AspNetCore.Server.IIS.Core.HttpReques
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddControllers();
            services.AddSingleton<IngredientRepository>();
            services.AddSingleton<StepRepository>();
            services.AddSingleton<RecipeRepository>();

            services.AddScoped<GlobalSchema>();


            //make IDependencyResolver available
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContex => httpContex.User);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<GlobalSchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
