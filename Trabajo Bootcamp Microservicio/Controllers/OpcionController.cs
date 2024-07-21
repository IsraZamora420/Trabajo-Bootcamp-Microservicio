using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpcionController : Controller
    {
        private readonly IOpcion _opcion;
        private ControlError Log = new ControlError();

        public OpcionController(IOpcion opcion)
        {
            this._opcion = opcion;
        }

        [HttpGet]
        [Route("GetOpcion")]
        public async Task<Respuesta> GetOpcion(int opcionId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _opcion.GetOpcion(opcionId);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("OpcionController", "GetOpcion", ex.Message);

            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostOpcion")]
        public async Task<Respuesta> PostOpcion([FromBody] Opcion opcion)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _opcion.PostOpcion(opcion);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("OpcionController", "PostOpcion", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutOpcion")]
        public async Task<Respuesta> PutOpcion([FromBody] Opcion opcion)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _opcion.PutOpcion(opcion);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("OpcionController", "PutOpcion", ex.Message);
            }
            return respuesta;
        }
    }
}

