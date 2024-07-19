using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IProveedor
    {
        //----------------------PROVEEDOR----------------------- 
        Task<Respuesta> GetProveedor();
        Task<Respuesta> PostProveedor(Proveedor proveedor);
        Task<Respuesta> PutProveedor(Proveedor proveedor);
        //------------------------------------------------------
    }
}
