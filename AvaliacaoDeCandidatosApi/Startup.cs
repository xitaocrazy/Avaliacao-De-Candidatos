using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Models;
using AvaliacaoDeCandidatosApi.Services;
using AvaliacaoDeCandidatosApi.Wrappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AvaliacaoDeCandidatosApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddTransient<IServicoDeQualificacaoDeCandidatos, ServicoDeQualificacaoDeCandidatos>();
            services.AddTransient<IServicoDeEnvioDeEmail, ServicoDeEnvioDeEmail>();
            services.AddTransient<ISmtpClient, SmtpClientWrapper>();
            services.AddSingleton<IConfiguration>(c => Configuration);
            services.Configure<ConfiguracaoSmtp>(Configuration.GetSection("ConfiguracaoSmtp"));

            services.AddCors(options => {
                options.AddPolicy("AllowAllOrigins",
                    builder => {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");
            app.UseMvc();
        }
    }
}
