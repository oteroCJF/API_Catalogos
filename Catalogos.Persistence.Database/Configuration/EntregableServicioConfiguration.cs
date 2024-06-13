using Catalogos.Domain.CTEntregables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Persistence.Database.Configuration
{
    public class EntregableServicioConfiguration
    {
        public EntregableServicioConfiguration(EntityTypeBuilder<EntregableServicio> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.EntregableId, x.ServicioId });
        }
    }
}
