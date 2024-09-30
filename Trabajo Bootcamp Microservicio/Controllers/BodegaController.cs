using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class BodegaController : Controller
    {
        private readonly IBodega _bodega;
        private ControlError Log = new ControlError();

        public BodegaController(IBodega bodega)
        {
            _bodega = bodega;
        }

        [HttpPost]
        [Route("GetBodega")]
        public async Task<Respuesta> GetBodega([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var bodegaDTO = new JsonLogDto();
            try
            {
                bodegaDTO = JsonConvert.DeserializeObject<JsonLogDto>(Convert.ToString(request.Data));
                respuesta = await _bodega.GetBodega(bodegaDTO.idBodega, bodegaDTO.bodegaNombre, bodegaDTO.bodegaIdSucursal);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("BodegaController", "GetBodega", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostBodega")]
        public async Task<Respuesta> PostBodega([FromBody] Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _bodega.PostBodega(bodega);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("BodegaController", "PostBodega", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutBodega")]
        public async Task<Respuesta> PutBodega([FromBody] Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _bodega.PutBodega(bodega);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("BodegaController", "PutBodega", ex.Message);
            }
            return respuesta;
        }
    }
}
