using Core.Application;
using Hangfire;
using Infrastructure.Database;
using TbilservingApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Infrastructure.Documents;

namespace TbilservingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }
        //public static void ConfigureCors(this IServiceCollection services)
        //{
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy(name: "AnyPolicy", builder => builder
        //            .AllowAnyOrigin() // დაშვება ეძლევა მოთხოვნას ნებისმიერი წყაროდან
        //            .AllowAnyMethod() // დაშვებას იძლევა HTTP ყველა მეთოდზე
        //            .AllowAnyHeader()
        //            .WithExposedHeaders("AccessToken"));
        //    });
        //}
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Presentation.WebApi", Version = "v1" });

                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "ქვედა ტექსტბოქსში ჩაწერეთ *_მხოლოდ_* თქვენი token !",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                  {
                    { jwtSecurityScheme, Array.Empty<string>() }
                  });

            });
            services.AddAutoMapper(typeof(Startup));
           


            services.AddAppLayer(Configuration);
            services.AddDbLayer(Configuration);
            services.AddDocumentLayer(Configuration);

            services.AddJwtAuthenticationConfigs(Configuration);
            services.AddJwtAuthorizationConfigs();

            services.AddCors(options =>
            {
                options.AddPolicy("AnyPolicy",
                builder =>
                {
                    // Not a permanent solution, but just trying to isolate the problem
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors("AnyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Presentation.TbilservingApp v1"));

           // app.UseMiddleware<LoggingMiddlewares>();


            app.UseHttpsRedirection();

            app.UseCors("AnyPolicy");
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


