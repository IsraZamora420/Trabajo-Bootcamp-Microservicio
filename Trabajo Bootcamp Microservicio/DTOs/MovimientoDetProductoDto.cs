using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class MovimientoDetProductoDto
    {
        public int MovidetProdId { get; set; }

        public int? MovicabId { get; set; }
        public int? ProductoId { get; set; }
        public string? ProductoNombre { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public short? Estado { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }

        public int? UsuIdAct { get; set; }
    }
}
