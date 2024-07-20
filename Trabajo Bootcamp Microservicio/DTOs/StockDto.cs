namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    internal class StockDto
    {
        public long ID { get; set; }
        public int EmpresaId { get; set; }
        public string NombreEmpresa { get; set; }
        public int SucursalId { get; set; }
        public string SucursalNombre { get; set; }
        public int BodegaId { get; set; }
        public string NombreBodega { get; set; }
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal? Precio { get; set; }
        public int? Cantidad { get; set; }
    }
}