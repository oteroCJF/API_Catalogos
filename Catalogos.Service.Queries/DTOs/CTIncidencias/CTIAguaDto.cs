﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogos.Service.Queries.DTOs.CTIncidencias
{
    public class CTIAguaDto
    {
        public int Id { get; set; }
        public int IncidenciaId { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
    }
}
