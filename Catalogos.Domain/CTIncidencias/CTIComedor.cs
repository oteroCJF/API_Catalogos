using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Domain.CTIncidencias
{
    public class CTIComedor
    {
        public int Id { get; set; }
        public int IncidenciaId { get; set; }
        public int TipoId { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
    }
}
