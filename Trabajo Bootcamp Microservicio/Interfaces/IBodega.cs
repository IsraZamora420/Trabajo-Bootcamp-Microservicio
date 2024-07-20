using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IBodega
    {
        Task<Respuesta> GetBodega(int BodegaId, string? BodegaNombre, int? SucursalId);
        Task<Respuesta> PostBodega(Bodega bodega);
        Task<Respuesta> PutBodega(Bodega bodega);
    }
}
