using Localiza.Componentes.ConjuntosNumericos.Services;
using Localiza.Componentes.ConjuntosNumericos.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Localiza.Componentes.ConjuntosNumericos
{
    /// <summary>
    /// A classe Startup configura servi�os e o pipeline de solicita��o do aplicativo.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///  Use este m�todo para adicionar servi�os ao cont�iner.
        /// </summary>
        /// <param name="services">Especifica o contrato para uma cole��o de descritores de servi�o.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDivisoresService, DivisoresService>();

            services.AddMvcCore().AddApiExplorer();
            
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Conjuntos N�mericos API",
                    Description = "Calculadora de Divisores e N�meros Primos em ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Natalia Cecilia",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        /// <summary>
        /// Use este m�todo para configurar o pipeline de solicita��o HTTP.
        /// </summary>
        /// <param name="app">Define uma classe que fornece os mecanismos para configurar o pipeline de solicita��o de um aplicativo.</param>
        public void Configure(IApplicationBuilder app)
        {
            // Configura��es do Swagger.
            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                   c.RoutePrefix = string.Empty;
               });

            // Configura��es das rotas de acesso aos endpoints da aplica��o.
            app.UseRouting()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllers();
               });
        }
    }
}
