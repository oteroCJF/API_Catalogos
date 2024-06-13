using Catalogos.Domain.CTActividadesContratos;
using Catalogos.Domain.CTDestinos;
using Catalogos.Domain.CTDiasInhabiles;
using Catalogos.Domain.CTEntregables;
using Catalogos.Domain.CTIncidencias;
using Catalogos.Domain.CTIndemnizaciones;
using Catalogos.Domain.CTMarcoJuridico;
using Catalogos.Domain.CTParametros;
using Catalogos.Domain.CTServicios;
using Catalogos.Domain.CTServiciosContratos;
using Catalogos.Persistence.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Catalogos.Persistence.Database
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CTServicio> Servicios { get; set; }
        public DbSet<CTServicioContrato> ServiciosContratos { get; set; }
        public DbSet<CTEntregable> Entregables { get; set; }
        public DbSet<CTIncidencia> Incidencias { get; set; }
        public DbSet<CTIAgua> CTIAgua { get; set; }
        public DbSet<CTIndemnizacion> Indemnizaciones { get; set; }
        public DbSet<CTIncidenciaIndemnizacion> IncidenciasIndemnizacion { get; set; }
        public DbSet<DiaInhabil> CTDiasInhabiles{ get; set; }
        public DbSet<CTILimpieza> CTILimpieza { get; set; }
        public DbSet<CTIFumigacion> CTIFumigacion { get; set; }
        public DbSet<CTIComedor> CTIComedor { get; set; }
        public DbSet<EntregableServicio> EntregableServicio { get; set; }
        public DbSet<CTActividadContrato> CTActividadesContratos { get; set; }
        public DbSet<CTDestino> CTDestinos { get; set; }
        public DbSet<CTParametro> Parametros { get; set; }
        public DbSet<MarcoJuridico> MarcoJuridico { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Catalogo");

            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTServicio>().ToTable("CTServicios");
            modelBuilder.Entity<CTParametro>().ToTable("CTParametros");
            modelBuilder.Entity<CTIncidencia>().ToTable("CTIncidencias");
            modelBuilder.Entity<CTIAgua>().ToTable("CTIAgua");
            modelBuilder.Entity<CTServicioContrato>().ToTable("CTServiciosContrato");
            modelBuilder.Entity<CTEntregable>().ToTable("CTEntregables");
            modelBuilder.Entity<CTILimpieza>().ToTable("CTILimpieza");
            modelBuilder.Entity<CTIFumigacion>().ToTable("CTIFumigacion");
            modelBuilder.Entity<CTActividadContrato>().ToTable("CTActividadesContratos");
            modelBuilder.Entity<CTIndemnizacion>().ToTable("CTIndemnizaciones");
            modelBuilder.Entity<CTIncidenciaIndemnizacion>().ToTable("CTIncidenciasIndemnizacion");
            modelBuilder.Entity<EntregableServicio>().ToTable("EntregablesServicio");
            modelBuilder.Entity<CTDestino>().ToTable("CTDestinosBM");
                
            new CTEntregableConfiguration(modelBuilder.Entity<CTEntregable>());
            new CTIncidenciaConfiguration(modelBuilder.Entity<CTIncidencia>());
            new CTILimpiezaConfiguration(modelBuilder.Entity<CTILimpieza>());
            new CTIFumigacionConfiguration(modelBuilder.Entity<CTIFumigacion>());
            new CTServicioConfiguration(modelBuilder.Entity<CTServicio>());
            new CTActividadContratoConfiguration(modelBuilder.Entity<CTActividadContrato>());
            new CTParametroConfiguration(modelBuilder.Entity<CTParametro>());
            new CTIndemnizacionConfiguration(modelBuilder.Entity<CTIndemnizacion>());
            new CTIncidenciaIndemnizacionConfiguration(modelBuilder.Entity<CTIncidenciaIndemnizacion>());
            new CTServicioContratoConfiguration(modelBuilder.Entity<CTServicioContrato>());
            new EntregableServicioConfiguration(modelBuilder.Entity<EntregableServicio>());
            new CTDestinosConfiguration(modelBuilder.Entity<CTDestino>());
        }
    }
}
