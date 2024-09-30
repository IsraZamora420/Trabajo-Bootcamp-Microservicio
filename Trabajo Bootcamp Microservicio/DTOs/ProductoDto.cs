using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class ProductoDto
    {
        public int ProdId { get; set; }

        public string? ProdDescripcion { get; set; }

        public decimal? ProdUltPrecio { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }

        public int? UsuIdAct { get; set; }

        public int? Estado { get; set; }
        public string? EstadoNombre { get; set; }

        public int? CategoriaId { get; set; }
        public string? CategoriaNombre { get; set; }

        public int? EmpresaId { get; set; }
        public string? EmpresaNombre { get; set; }

        public int? ProveedorId { get; set; }
        public string? ProveedorNombre { get; set; }

    }
}
