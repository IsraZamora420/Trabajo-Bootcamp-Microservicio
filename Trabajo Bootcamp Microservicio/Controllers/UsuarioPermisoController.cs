using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPermisoController : ControllerBase
    {
        private readonly IUsuarioPermiso _usuarioPermiso;

        public UsuarioPermisoController(IUsuarioPermiso usuarioPermiso)
        {
            _usuarioPermiso = usuarioPermiso;
        }

        [HttpGet]
        [Route("GetUsuarioPermiso")]
        public async Task<Respuesta> GetUsuarioPermiso(int PermisoId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _usuarioPermiso.GetUsuarioPermiso(PermisoId);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("CreateUsuarioPermiso")]
        public async Task<Respuesta> CreateUsuarioPermiso([FromBody] UsuarioPermiso usuarioPermiso)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _usuarioPermiso.CreateUsuarioPermiso(usuarioPermiso);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = $"Un error ocurrio {ex}";
            }
            return respuesta;
        }
    }
}
