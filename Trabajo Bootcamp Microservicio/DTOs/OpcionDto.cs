using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class OpcionDto
    {
        public int OpcionId { get; set; }

        public string? OpcionDescripcion { get; set; }

        public short? Estado { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }

        public int? UsuIdAct { get; set; }

        public int? ModuloId { get; set; }
        public string? ModuloDescripcion { get; set; }

    }
}
