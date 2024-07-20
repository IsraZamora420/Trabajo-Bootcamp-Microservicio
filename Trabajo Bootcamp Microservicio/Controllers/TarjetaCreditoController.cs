using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaCreditoController : ControllerBase
    {
        private readonly ITarjetaCredito _tarjetaCredito;
        private ControlError Log = new ControlError();

        public TarjetaCreditoController(ITarjetaCredito tarjetaCredito)
        {
            this._tarjetaCredito = tarjetaCredito;
        }

        [HttpGet]
        [Route("GetTarjetaCredito")]
        public async Task<Respuesta> GetTarjetaCredito(int tarjetaId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _tarjetaCredito.GetTarjetaCredito(tarjetaId);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("ProductoController", "GetTarjetaCredito", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostTarjetaCredito")]
        public async Task<Respuesta> CreateTarjetaCredito([FromBody] TarjetaCredito tarjetaCredito)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _tarjetaCredito.PostTarjetaCredito(tarjetaCredito);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PostTarjetaCredito", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutTarjetaCredito")]
        public async Task<Respuesta> PutTarjetaCredito([FromBody] TarjetaCredito tarjetaCredito)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _tarjetaCredito.PutTarjetaCredito(tarjetaCredito);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PutTarjetaCredito", ex.Message);
            }
            return respuesta;
        }
    }
}
