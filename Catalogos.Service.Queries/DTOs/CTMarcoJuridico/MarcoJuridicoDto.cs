using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Service.Queries.DTOs.CTMarcoJuridico
{
    public class MarcoJuridicoDto
    {
        public int Id { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Entregable { get; set; }
    }
}
