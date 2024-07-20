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
    public async Task<Respuesta> GetProveedor(int provId, string? nombreProveedor, string identificacion)
     {
         var respuesta = new Respuesta();
         try
         {
             respuesta = await _proveedor.GetProveedor(provId, nombreProveedor,identificacion);
         }
         catch (Exception ex)
         {
             Log.LogErrorMetodos("ProveedorController", "GetProveedor", ex.Message);
         }
         return respuesta;
     }

        [HttpPost]
        [Route("PostProveedor")]
        public async Task<Respuesta> PostProveedor([FromBody] Proveedor proveedor)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _proveedor.PostProveedor(proveedor);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProveedorController", "PostProveedor", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutProveedor")]
        public async Task<Respuesta> PutProveedor([FromBody] Proveedor proveedor)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _proveedor.PutProveedor(proveedor);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProveedorController", "PutProveedor", ex.Message);
            }
            return respuesta;
        }
        //----------------------------------------------------------------------------------------------

    }
}
