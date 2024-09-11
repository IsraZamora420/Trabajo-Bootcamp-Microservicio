using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    public class UsuarioRolController : Controller
    {
        private readonly IUsuarioRol _usuarioRol;
        private ControlError Log = new ControlError();
        public UsuarioRolController(IUsuarioRol usuarioRol)
        {
            this._usuarioRol = usuarioRol;
        }
        [HttpPost]
        [Route("GetUsuarioRol")]
        public async Task<Respuesta> GetUsuarioRol([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var usuarioRolDto = new UsuarioRolDto();
            try
            {
                var json = JsonConvert.SerializeObject(request.Data);
                usuarioRolDto = JsonConvert.DeserializeObject<UsuarioRolDto> (json);
                
                respuesta = await _usuarioRol.GetUsuarioRol(usuarioRolDto.UsuRolId, Convert.ToInt32(usuarioRolDto.UsuId), Convert.ToInt32(usuarioRolDto.RolId));
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("UsuarioRolController", "GetUsuarioRol", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostUsuarioRol")]
        public async Task<Respuesta> PostUsuarioRol([FromBody] UsuarioRol usuarioRol)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _usuarioRol.PostUsuarioRol(usuarioRol);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("UsuarioRolController", "PostUsuarioRol", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutUsuarioRol")]
        public async Task<Respuesta> PutUsuarioRol([FromBody] UsuarioRol usuarioRol)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _usuarioRol.PutUsuarioRol(usuarioRol);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("UsuarioRolController", "PutUsuarioRol", ex.Message);
            }
            return respuesta;
        }
        //----------------------------------------------------------------------------------------------
    }
}
