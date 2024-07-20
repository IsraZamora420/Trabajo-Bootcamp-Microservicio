using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class MovimientoDetPagosDto
    {
        public int MovidetPagoId { get; set; }

        public int? MovicabId { get; set; }

        public int? FpagoId { get; set; }
        public string? FpagoNombre { get; set; }

        public decimal? ValorPagado { get; set; }

        public int? IndustriaId { get; set; }
        public string? IndustriaNombre { get; set; }

        public string? Lote { get; set; }

        public string? Voucher { get; set; }

        public int? TarjetacredId { get; set; }
        public string? TarjetacredNombre { get; set; }

        public int? BancoId { get; set; }

        public int? ComprobanteId { get; set; }

        public string? FechaPago { get; set; }

        public int? ClienteId { get; set; }
        public string? ClienteNombre { get; set; }
    }
}
