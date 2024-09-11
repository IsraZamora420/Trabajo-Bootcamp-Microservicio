using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoDetProdController : Controller
    {
        private readonly IMovimientoDetProd _movimientoDetProd;
        private ControlError Log = new ControlError();

        public MovimientoDetProdController(IMovimientoDetProd movimientoDetProd)
        {
            this._movimientoDetProd = movimientoDetProd;
        }

        [HttpPost]
        [Route("GetMovimientoDetProd")]
        public async Task<Respuesta> GetMovimientoDetProd([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var movDetProd = new JsonLogDto();
            try
            {
                movDetProd = JsonConvert.DeserializeObject<JsonLogDto>(Convert.ToString(request.Data));
                respuesta = await _movimientoDetProd.GetMovimientoDetProd(movDetProd.idMovDetProd);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoDetProdController", "GetMovimientoDetProd", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostMovimientoDetProd")]
        public async Task<Respuesta> PostMovimientoDetProd([FromBody] MovimientoDetProducto movimientoDetProducto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _movimientoDetProd.PostMovimientoDetProd(movimientoDetProducto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoDetProdController", "PostMovimientoDetProd", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutMovimientoDetProd")]
        public async Task<Respuesta> PutMovimientoDetProd([FromBody] MovimientoDetProducto movimientoDetProducto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _movimientoDetProd.PutMovimientoDetProd(movimientoDetProducto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoDetProdController", "PutMovimientoDetProd", ex.Message);
            }
            return respuesta;
        }
    }
}
