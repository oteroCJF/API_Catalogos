using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Service.Queries.DTOs.CTDiasInhabiles
{
    public class DiaInhabilDto
    {
        public int Id { get; set; }
        public int Anio { get; set; }
        public DateTime FechaInhabil { get; set; }
    }
}
