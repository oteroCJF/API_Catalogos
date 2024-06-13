using Catalogos.Persistence.Database;
using Catalogos.Service.Queries.Queries.CTEntregables;
using Catalogos.Service.Queries.Queries.CTIncidencias;
using Catalogos.Service.Queries.Queries.CTIndemnizaciones;
using Catalogos.Service.Queries.Queries.CTParametros;
using Catalogos.Service.Queries.Queries.CTActividadesContratos;
using Catalogos.Service.Queries.Queries.CTServicios;
using Catalogos.Service.Queries.Queries.CTServiciosContratos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogos.Service.Queries.Queries.CTDiasInhabiles;
using Catalogos.Service.Queries.Queries.CTMarcoJuridico;

namespace AEElectrica.Api
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
            services.AddDbContext<ApplicationDbContext>(opts =>
              opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
              x => x.MigrationsHistoryTable("__EFMigrationHistory", "Catalogo")
              )
          );
            
            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; options.JsonSerializerOptions.PropertyNameCaseInsensitive = false; });

            services.AddTransient<ICTEntregableQueryService, CTEntregableQueryService>();
            services.AddTransient<ICTIAguaQueryService, CTIAguaQueryService>();
            services.AddTransient<ICTIncidenciaQueryService, CTIncidenciaQueryService>();
            services.AddTransient<ICTServicioQueryService, CTServicioQueryService>();
            services.AddTransient<ICTServicioContratoQueryService, CTServicioContratoQueryService>();
            services.AddTransient<ICTParametroQueryService, CTParametroQueryService>();
            services.AddTransient<ICTILimpiezaQueryService, CTILimpiezaQueryService>();
            services.AddTransient<ICTIFumigacionQueryService, CTIFumigacionQueryService>();
            services.AddTransient<ICTIComedorQueryService, CTIComedorQueryService>();
            services.AddTransient<ICTIndemnizacionQueryService, CTIndemnizacionQueryService>();
            services.AddTransient<ICTACQueryServiceQueryService, CTACQueryServiceQueryService>();
            services.AddTransient<ICTDestinoQueryService, CTDestinoQueryService>();
            services.AddTransient<IDiaInhabilQueryService, DiaInhabilQueryService>();
            services.AddTransient<IMarcoJuridicoQueryService, MarcoJuridicoQueryService>();

            var secretKey = Encoding.ASCII.GetBytes(
               Configuration.GetValue<string>("SecretKey")
           );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
