using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.AplicacionWeb.Models.ViewModels;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.AplicacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
            private readonly IUsuarioService _usuarioServicio;

            public LoginApiController(IUsuarioService usuarioServicio)
            {
                _usuarioServicio = usuarioServicio;
            }

            [HttpPost("login")]

            public async Task<IActionResult> Login([FromBody] VMUsuarioLogin modelo)
            {
                try
                {
                    Usuario usuario_encontrado = await _usuarioServicio.ObtenerPorCredenciales(modelo.Correo, modelo.Clave);

                    if (usuario_encontrado == null)
                    {
                        return Unauthorized("Credenciales inválidas");
                    }
                    if (usuario_encontrado.IdRol != 1)
                    {
                        return Unauthorized("Acceso no autorizado");
                    }
                
                var usuarioResponse = new
                    {
                        IdUsuario = usuario_encontrado.IdUsuario,
                        Nombre = usuario_encontrado.Nombre,
                        Correo = usuario_encontrado.Correo,
                        
                    };

                    return Ok(usuarioResponse);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Error interno del servidor");
                }
            }
        
    }
}
