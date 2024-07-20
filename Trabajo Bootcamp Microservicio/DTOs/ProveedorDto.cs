namespace Trabajo_Bootcamp_Microservicio.DTOs
{
    public class ProveedorDto
    {
        public int ProvId { get; set; }

        public string? ProvRuc { get; set; }

        public string? ProvNomComercial { get; set; }

        public string? ProvRazon { get; set; }

        public string? ProvDireccion { get; set; }

        public int? ProvTelefono { get; set; }

        public int? CiudadId { get; set; }
        public string? CiudadNombre { get; set; }

        public string? Estado { get; set; }

        public DateTime? FechaHoraReg { get; set; }

        public DateTime? FechaHoraAct { get; set; }

        public int? UsuIdReg { get; set; }

        public int? UsuIdAct { get; set; }


    }
}
