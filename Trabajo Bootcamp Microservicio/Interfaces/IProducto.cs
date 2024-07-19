using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IProducto
    {
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> GetProducto(int idProducto);
        
    }
}
