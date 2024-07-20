using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface ISucursal
    {
        Task<Respuesta> GetSucursal(int SucursalId, string? SucursalRuc, string? SucursalNombre);
        Task<Respuesta> PostSucursal(Sucursal sucursal);
        Task<Respuesta> PutSucursal(Sucursal sucursal);
    }
}
