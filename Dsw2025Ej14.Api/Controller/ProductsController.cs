using Dsw2025Ej14.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Dsw2025Ej14.Api.Domain;
namespace Dsw2025Ej14.Api.Controller
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        private readonly IPersistencia _persistencia;

        public ProductsController(IPersistencia persistencia)
        {
            _persistencia = persistencia;
        }

        [HttpGet("products")]
        public IActionResult GetAllActive()
        {
            var productosActivos = _persistencia.ObtenerProductos()
                                                 .Where(p => p.IsActive)
                                                 .ToList();

            if (productosActivos.Any())
                return Ok(productosActivos);

            return NoContent();
        }

        
    }
}