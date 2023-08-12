using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using snedson_ecology_backend.core.Interfaces;
using snedson_ecology_backend.core.ExtensionMethods;
using snedson_ecology_backend.infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snedson_ecology_backend.infrastructure.NamingPolicies;

namespace snedson_ecology_backend
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

            services.AddControllers()
                .AddJsonOptions(
                    options => {
                        options.JsonSerializerOptions.PropertyNamingPolicy =
                            SnakeCaseNamingPolicy.Instance;
                    });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "snedson_ecology_backend", Version = "v1" });
            });

            services.AddDbContext<EcologyContext>(
                options => {
                    options
                    .UseLazyLoadingProxies()
                    .UseNpgsql(Configuration.GetConnectionString("EcologyConnectionString"));
                });

            services.AddScoped<IEcologyContext>(provider =>
                provider.GetService<EcologyContext>());

            services.AddCoreInjections();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "snedson_ecology_backend v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
