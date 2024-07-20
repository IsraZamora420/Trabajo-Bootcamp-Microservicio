using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IMovimientoCab
    {
        Task<Respuesta> GetMovimientoCab(int idMovimientoCab);
        Task<Respuesta> PostMovimientoCab(MovimientoCab movimientoCab);
        Task<Respuesta> PutMovimientoCab(MovimientoCab movimientoCab);

    }
}
