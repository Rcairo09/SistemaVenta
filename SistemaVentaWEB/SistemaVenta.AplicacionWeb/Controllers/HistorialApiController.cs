using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.AplicacionWeb.Models.ViewModels;
using SistemaVenta.BLL.Interfaces;

namespace SistemaVenta.AplicacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialApiController : ControllerBase
    {
        private readonly IVentaService _ventaServicio;
        private readonly IMapper _mapper;

        public HistorialApiController(IVentaService ventaServicio, IMapper mapper)
        {
            _ventaServicio = ventaServicio;
            _mapper = mapper;
        }

        [HttpGet("ventas")]
        public async Task<IActionResult> ObtenerHistorialVentas(string numeroVenta, string fechaInicio, string fechaFin)
        {
            try
            {
                var historialVentas = await _ventaServicio.Historial(numeroVenta, fechaInicio, fechaFin);

                // Puedes mapear las ventas a tu ViewModel (VMVenta) aquí si es necesario
                var vmHistorialVentas = _mapper.Map<List<VMVenta>>(historialVentas);

                return StatusCode(StatusCodes.Status200OK, vmHistorialVentas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
