using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface ITarjetaCredito
    {
        Task<Respuesta> GetTarjetaCredito(int tarjetaId);
        Task<Respuesta> PostTarjetaCredito(TarjetaCredito tarjetaCredito);
        Task<Respuesta> PutTarjetaCredito(TarjetaCredito tarjetaCredito);
    }
}
