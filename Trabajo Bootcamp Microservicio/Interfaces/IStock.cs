using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IStock
    {
        Task<Respuesta> GetStock(int? EmpresaId, int? SucursalId, int? BodegaId, int? ProdId);
        Task<Respuesta> PutStock(Stock stock);
        Task<Respuesta> PostStock(Stock stock);
    }
}
