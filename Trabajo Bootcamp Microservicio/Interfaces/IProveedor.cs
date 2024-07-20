using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface IProveedor
    {
        //----------------------PROVEEDOR----------------------- 
        Task<Respuesta> GetProveedor(int provId, string? nombreProveedor, string identificacion);
       // Task<Respuesta> GetProveedorF();
        Task<Respuesta> PostProveedor(Proveedor proveedor);
        Task<Respuesta> PutProveedor(Proveedor proveedor);
        //------------------------------------------------------
    }
}
