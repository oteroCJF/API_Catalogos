using Catalogos.Domain.CTEntregables;
using Catalogos.Domain.CTServicios;
using Catalogos.Domain.CTServiciosContratos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTServicioContratoConfiguration
    {
        public CTServicioContratoConfiguration(EntityTypeBuilder<CTServicioContrato> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
