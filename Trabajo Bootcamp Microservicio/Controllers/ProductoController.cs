using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Trabajo_Bootcamp_Microservicio.DTOs;
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

        [HttpPost]
        [Route("GetProducto")]
        public async Task<Respuesta> GetProducto([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var productoDTO = new JsonLogDto();
            try
            {
                //var json = JsonConvert.SerializeObject(request.Data);
                productoDTO = JsonConvert.DeserializeObject<JsonLogDto>(Convert.ToString(request.Data));
                respuesta = await _producto.GetProducto(productoDTO.idProducto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "GetProducto", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PutProducto", ex.Message);
            }
            return respuesta;
        }
    }
}
