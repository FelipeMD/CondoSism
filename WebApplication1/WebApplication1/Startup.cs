using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;
using WebApplication1.Domain.Apartamentos;
using WebApplication1.Domain.Apartamentos.Interfaces;
using WebApplication1.Domain.Context;
using WebApplication1.Domain.Moradores;
using WebApplication1.Domain.Moradores.Interfaces;
using WebApplication1.Hypermedia.Enricher;
using WebApplication1.Hypermedia.Filters;
using WebApplication1.Infrastructure.Generic;

namespace WebApplication1
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console().CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
            
            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }
            
            /*Exibe como XML*/
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml",
                    MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json",
                    MediaTypeHeaderValue.Parse("application/jason"));
            }).AddXmlDataContractSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new MoradorEnricher());
            filterOptions.ContentResponseEnricherList.Add(new ApartamentoEnricher());
            
            services.AddSingleton(filterOptions);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "REST API's using Azure with AST.NET Core 5 and Docker",
                        Version = "v1",
                        Description = "API RESTful developed in 'REST API's using Azure with AST.NET Core 5 and Docker'",
                        Contact = new OpenApiContact
                        {
                            Name = "Felipe Souza",
                            Url = new Uri("https://github.com/FelipeMD")
                        }
                    });
            });
            
            services.AddControllers();
            
            services.AddScoped<IMoradorService, MoradorService>();
            services.AddScoped<IApartamentoService, ApartamentoService>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                    "REST API's using Azure with AST.NET Core 5 and Docker - v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id}");
            });
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
    }
}
