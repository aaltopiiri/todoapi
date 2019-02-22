using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Models;
using Swashbuckle.AspNetCore.Swagger;
//using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;


namespace TodoApi
{
    /* 
        public class TestFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Schemes = new string[] { "http" };
        }
    }
    */
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<TodoContext>(opt =>
            opt.UseInMemoryDatabase("TodoList"));

            // Register the Swagger generator, defining 1 or more Swagger documents

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            /* 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Swashbuckle.AspNetCore.Swagger.Info
                { Title = "My API", Version = "v2" });
                c.DocumentFilter<TestFilter>();
            });

            */

            // IHostingEnvironment (stored in _env) is injected into the Startup class.
            /* 
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                options.HttpsPort = 5001;
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "My API V1");
                //c.SwaggerEndpoint("http://localhost:8000/swagger/v1/swagger.json", "My API V1");
                //c.SwaggerEndpoint("https://localhost:8001/swagger/v1/swagger.json", "My API V1");
            
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseMvc();
        }
    }
}
