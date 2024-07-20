using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IMovimientoDetPagos
    {
        Task<Respuesta> GetMovimientoDetPagos(int idMovimientoDetPagos);
        Task<Respuesta> PostMovimientoDetPagos(MovimientoDetPago movimientoDetPago);
        Task<Respuesta> PutMovimientoDetPagos(MovimientoDetPago movimientoDetPago);
    }
}
