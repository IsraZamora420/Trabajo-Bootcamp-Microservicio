using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IPuntoVenta
    {
        Task<Respuesta> GetPuntoVenta(int PuntovtaId, string? PuntovtaNombre, int? PuntoEmisionId);
        Task<Respuesta> PostPuntoVenta(PuntoVentum puntoVenta);
        Task<Respuesta> PutPuntoVenta(PuntoVentum puntoVenta);

        Task<Respuesta> GetPuntoEmisionSRI(int PuntoEmisionId, string? PuntoEmision, int? EmpresaId, int? SucursalId, string? CodEstablecimientoSri);
        Task<Respuesta> PostPuntoEmisionSRI(PuntoEmisionSri puntoSRI);
        Task<Respuesta> PutPuntoEmisionSRI(PuntoEmisionSri puntoSRI);
    }
}
