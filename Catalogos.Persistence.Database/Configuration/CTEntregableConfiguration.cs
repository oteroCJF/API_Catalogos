using Catalogos.Domain.CTEntregables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Persistence.Database.Configuration
{
    public class CTEntregableConfiguration
    {
        public CTEntregableConfiguration(EntityTypeBuilder<CTEntregable> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
