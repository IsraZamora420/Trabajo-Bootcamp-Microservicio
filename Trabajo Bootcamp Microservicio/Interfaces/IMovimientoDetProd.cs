using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IMovimientoDetProd
    {
        Task<Respuesta> GetMovimientoDetProd(int idMovimientoDetProducto);
        Task<Respuesta> PostMovimientoDetProd(MovimientoDetProducto movimientoDetProducto);
        Task<Respuesta> PutMovimientoDetProd(MovimientoDetProducto movimientoDetProducto);
    }
}
