using System.Text.RegularExpressions;
using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> GetRol();
        Task<Respuesta> PostRol(Rol rol);
        Task<Respuesta> PutRol(Rol rol);

        Task<Respuesta> GetProveedor();
        Task<Respuesta> PostProveedor(Proveedor proveedor);
        Task<Respuesta> PutProveedor(Proveedor proveedor);

        Task<Respuesta> GetTipoMovimiento();
        Task<Respuesta> PostTipoMovimiento(TipoMovimiento tipoMovimiento);
        Task<Respuesta> PutTipoMovimiento(TipoMovimiento tipoMovimiento);

        Task<Respuesta> GetUsuario();
        Task<Respuesta> PostUsuario(Usuario usuario);
        Task<Respuesta> PutUsuario(Usuario usuario);

    }
}
