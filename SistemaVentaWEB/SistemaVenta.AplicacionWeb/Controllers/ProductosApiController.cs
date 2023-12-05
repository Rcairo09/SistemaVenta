using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Implementacion;
using SistemaVenta.BLL.Interfaces;

namespace SistemaVenta.AplicacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosApiController : ControllerBase
    {
        protected readonly IProductoService _productoService;

        public ProductosApiController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> ObtenerProductosAsync()
        {
            try
            {
                var productos = await _productoService.Lista();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                // Loguea o maneja el error de alguna manera
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
