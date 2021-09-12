using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai.inlock.webApi_
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "senai.inlock.webApi"

                });

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });


            services

                 //define a forma de autentica��o
                 .AddAuthentication(options =>
                 {
                     options.DefaultAuthenticateScheme = "JwtBearer";
                     options.DefaultChallengeScheme = "JwtBearer";
                 })

            //etapa de defini��o dos par�metros de valida��o
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //ser� validado o emissor
                    ValidateIssuer = true,

                    //ser�r validado o destinat�rio do token
                    ValidateAudience = true,

                    //ser� validado o tempo do token
                    ValidateLifetime = true,

                    //defini��o da chave de seguran�a
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ASUE9APSHF-JPOQWI-FUJ")),

                    //tempo de verifica��o do token
                    ClockSkew = TimeSpan.FromHours(1),

                    //nome do emissor
                    ValidIssuer = "senai.inlock.webApi",

                    //nome do destinat�rio
                    ValidAudience = "senai.inlock.webApi"
                };
            }); 
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Filmes.webApi");
                c.RoutePrefix = string.Empty;
            });

            //habilita autentica��o
            app.UseAuthentication(); //401

            //habilita autoriza��o
            app.UseAuthorization(); //403

            app.UseEndpoints(endpoints =>
            {
            //define o mapeamento dos controllers
            endpoints.MapControllers();
            });

        }
    }
}

