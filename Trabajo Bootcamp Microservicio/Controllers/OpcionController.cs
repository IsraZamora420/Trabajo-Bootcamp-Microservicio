using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcionController : ControllerBase
    {
        private readonly IOpcion _opcion;

        public OpcionController(IOpcion opcion)
        {
            _opcion = opcion;
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
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("CreateOpcion")]
        public async Task<Respuesta> CreateOpcion([FromBody] Opcion opcion)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _opcion.CreateOpcion(opcion);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = $"Un error ocurrio {ex}";
            }
            return respuesta;
        }
    }
}

