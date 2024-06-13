using Catalogos.Domain.CTEntregables;
using Catalogos.Domain.CTParametros;
using Catalogos.Domain.CTServicios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTParametroConfiguration
    {
        public CTParametroConfiguration(EntityTypeBuilder<CTParametro> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
