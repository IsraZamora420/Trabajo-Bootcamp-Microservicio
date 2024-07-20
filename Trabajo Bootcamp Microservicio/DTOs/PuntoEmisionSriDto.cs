namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    internal class PuntoEmisionSriDto
    {
        public int PuntoEmisionId { get; set; }
        public string PuntoEmision { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNombre { get; set; }
        public int SucursalId { get; set; }
        public string SucursalNombre { get; set; }
        public string CodEstablecimientoSri { get; set; }
        public int? UltSecuencia { get; set; }
        public short? Estado { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public int? UsuIdReg { get; set; }
        public DateTime? FechaHoraAct { get; set; }
        public int? UsuIdAct { get; set; }
    }
}