using Catalogos.Domain.CTActividadesContratos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTActividadContratoConfiguration
    {
        public CTActividadContratoConfiguration(EntityTypeBuilder<CTActividadContrato> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
