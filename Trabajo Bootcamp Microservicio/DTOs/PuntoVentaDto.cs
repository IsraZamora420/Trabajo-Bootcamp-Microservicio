namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    internal class PuntoVentaDto
    {
        public int PuntovtaId { get; set; }
        public string PuntovtaNombre { get; set; }
        public int PuntoEmisionId { get; set; }
        public string PuntoEmision { get; set; }
        public int SucursalId { get; set; }
        public string SucursalNombre { get; set; }
        public short? Estado { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public int? UsuIdReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int? UsuIdAct { get; set; }
    }
}