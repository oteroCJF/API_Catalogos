using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Service.Queries.DTOs.CTParametros
{
    public class CTParametroDto
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public string Tipo { get; set; }
        public string Tabla { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
