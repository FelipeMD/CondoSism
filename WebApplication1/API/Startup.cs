using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using API.Configurations;
using API.Domain.Context;
using API.Domain.Entities.Moradores.Interfaces;
using API.Domain.Entities.Users.Interfaces;
using API.Domain.Generics;
using API.Hypermedia.Enricher;
using API.Hypermedia.Filters;
using API.Infrastructure.Repositories;
using API.Services;
using API.Services.Implementations;
using Application.Services.Apartamentos;
using Application.Services.Apartamentos.Interfaces;
using Application.Services.Files;
using Application.Services.Files.Interfaces;
using Application.Services.Login;
using Application.Services.Login.Interfaces;
using Application.Services.Moradores;
using Application.Services.Moradores.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;

namespace API
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
            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenConfigurations.Issuer,
                        ValidAudience = tokenConfigurations.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
                    };
                });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser()
                    .Build());
            });
            
            // services.AddCors(options => options.AddDefaultPolicy(builder =>
            // {
            //     builder.AllowAnyOrigin()
            //         .AllowAnyMethod()
            //         .AllowAnyHeader();
            // }));
            
            services.AddControllers();
            
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
                        Title = "SistemaCondominio",
                        Version = "v1",
                        Description = "API RESTful developed in AST.NET Core 5",
                        Contact = new OpenApiContact
                        {
                            Name = "Felipe Souza",
                            Url = new Uri("https://github.com/FelipeMD")
                        }
                    });
            });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped<IMoradorService, MoradorService>();
            services.AddScoped<IApartamentoService, ApartamentoService>();
            
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IFileService, FileService>();
            
            services.AddTransient<ITokenService, TokenService>();

            services.AddScoped<IUserRepository, Infrastructure.UserRepository>();
            services.AddScoped<IMoradorRepository, MoradorRepository>();

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

            app.UseCors();

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                    "API RESTful developed in AST.NET Core 5 - v1");
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
