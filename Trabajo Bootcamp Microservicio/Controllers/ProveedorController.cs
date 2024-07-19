using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProveedorController : Controller
    {
        private readonly IProveedor _proveedor;
        private ControlError Log = new ControlError();
        public ProveedorController(IProveedor proveedor)
        {
            this._proveedor = proveedor;
        }

     [HttpGet]
     [Route("GetProveedor")]
     public async Task<Respuesta> GetProveedor()
     {
         var respuesta = new Respuesta();
         try
         {
             respuesta = await _proveedor.GetProveedor();
         }
         catch (Exception ex)
         {
             Log.LogErrorMetodos("CatalogoController", "GetProveedor", ex.Message);
         }
         return respuesta;
     }

    }
}
