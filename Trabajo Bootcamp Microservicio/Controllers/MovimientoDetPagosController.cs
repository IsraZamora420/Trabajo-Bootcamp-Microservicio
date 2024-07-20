using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoDetPagosController : Controller
    {
        private readonly IMovimientoDetPagos _movimientoDetPagos;
        private ControlError Log = new ControlError();

        public MovimientoDetPagosController(IMovimientoDetPagos movimientoDetPagos)
        {
            this._movimientoDetPagos = movimientoDetPagos;
        }

        [HttpGet]
        [Route("GetMovimientoDetPagos")]
        public async Task<Respuesta> GetMovimientoDetPagos(int idMovimientoDetPagos)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _movimientoDetPagos.GetMovimientoDetPagos(idMovimientoDetPagos);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoDetPagosController", "GetMovimientoDetPagos", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostMovimientoDetPagos")]
        public async Task<Respuesta> PostMovimientoDetPagos([FromBody] MovimientoDetPago movimientoDetPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _movimientoDetPagos.PostMovimientoDetPagos(movimientoDetPago);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoDetPagosController", "PostMovimientoDetPagos", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutMovimientoDetPagos")]
        public async Task<Respuesta> PutMovimientoDetPagos([FromBody] MovimientoDetPago movimientoDetPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _movimientoDetPagos.PutMovimientoDetPagos(movimientoDetPago);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("MovimientoDetPagosController", "PutMovimientoDetPagos", ex.Message);
            }
            return respuesta;
        }
    }
}
