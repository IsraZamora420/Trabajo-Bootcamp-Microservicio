using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class TarjetaCreditoDto
    {
        public int TarjetacredId { get; set; }

        public string? TarjetacredDescripcion { get; set; }

        public int? IndustriaId { get; set; }
        public string? IndustriaNombre { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }

        public int? UsuIdAct { get; set; }

    }
}
