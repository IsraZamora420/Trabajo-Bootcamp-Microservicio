﻿namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class CiudadDto
    {
        public int CiudadId { get; set; }

        public string? CiudadNombre { get; set; }

        public int? Estado { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }

        public int? UsuIdAct { get; set; }

        public int? PaisId { get; set; }
        public string? PaisNombre { get; set; }

    }
}
