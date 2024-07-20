using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoCabController : Controller
    {
        private readonly IMovimientoCab _movimientoCab;
        private ControlError Log = new ControlError();

        public MovimientoCabController(IMovimientoCab movimientoCab)
        {
            this._movimientoCab = movimientoCab;
        }

        [HttpGet]
        [Route("GetMovimientoCab")]
        public async Task<Respuesta> GetMovimientoCab(int idMovimientoCab)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _movimientoCab.GetMovimientoCab(idMovimientoCab);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoCabController", "GetMovimientoCab", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostMovimientoCab")]
        public async Task<Respuesta> PostMovimientoCab([FromBody] MovimientoCab movimientoCab)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _movimientoCab.PostMovimientoCab(movimientoCab);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoCabController", "PostMovimientoCab", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutMovimientoCab")]
        public async Task<Respuesta> PutMovimientoCab([FromBody] MovimientoCab movimientoCab)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _movimientoCab.PutMovimientoCab(movimientoCab);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoCabController", "PutMovimientoCab", ex.Message);
            }
            return respuesta;
        }

    }
}
