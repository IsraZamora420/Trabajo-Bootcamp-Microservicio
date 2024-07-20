using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioPermisoController : Controller
    {
        private readonly IUsuarioPermiso _usuarioPermiso;
        private ControlError Log = new ControlError();

        public UsuarioPermisoController(IUsuarioPermiso usuarioPermiso)
        {
            this._usuarioPermiso = usuarioPermiso;
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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("UsuarioPermisoController", "GetUsuarioPermiso", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostUsuarioPermiso")]
        public async Task<Respuesta> PostUsuarioPermiso([FromBody] UsuarioPermiso usuarioPermiso)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _usuarioPermiso.PostUsuarioPermiso(usuarioPermiso);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("UsuarioPermisoController", "PostUsuarioPermiso", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutUsuarioPermiso")]
        public async Task<Respuesta> PutUsuarioPermiso([FromBody] UsuarioPermiso usuarioPermiso)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _usuarioPermiso.PutUsuarioPermiso(usuarioPermiso);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("UsuarioPermisoController", "PutUsuarioPermiso", ex.Message);
            }
            return respuesta;
        }
    }
}
