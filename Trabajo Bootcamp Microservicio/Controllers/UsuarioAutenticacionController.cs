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
    public class UsuarioAutenticacionController : Controller
    {
        private readonly IUsuarioAutenticacion _usuarioAutenticacion;
        private ControlError Log = new ControlError();

        public UsuarioAutenticacionController(IUsuarioAutenticacion usuarioAutenticacion)
        {
            this._usuarioAutenticacion = usuarioAutenticacion;
        }

        [HttpPost]
        [Route("GetUsuarioAutenticacion")]
        public async Task<Respuesta> GetUsuarioAutenticacion([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var userDto = new JsonLogDto();
            try
            {
                userDto = JsonConvert.DeserializeObject<JsonLogDto>(Convert.ToString(request.Data));
                respuesta = await _usuarioAutenticacion.GetUsuarioAutenticacion(userDto.user, userDto.password);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("UsuarioAutenticacionController", "GetUsuarioAutenticacion", ex.Message);
            }
            return respuesta;
        }

    }
}
