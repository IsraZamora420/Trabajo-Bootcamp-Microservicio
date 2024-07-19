using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProducto _producto;
        private ControlError Log = new ControlError();

        public ProductoController(IProducto producto)
        {
            this._producto = producto;
        }

        //-------------------------------------------PRODUCTO------------------------------------------
        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PostProducto", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetProducto")]
        public async Task<Respuesta> GetProducto(int idProducto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.GetProducto(idProducto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "GetProducto", ex.Message);
            }
            return respuesta;
        }
    }
}
