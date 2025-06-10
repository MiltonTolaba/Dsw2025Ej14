using Dsw2025Ej14.Api.Data;
using Microsoft.AspNetCore.Mvc;
namespace Dsw2025Ej14.Api.Controller
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        private readonly PersistenciaEnMemoria _persistencia;
        public ProductsController(PersistenciaEnMemoria persistencia)
        {
            _persistencia = persistencia;
        }

        [HttpGet("products")]
        public IActionResult GetAllActive()
        {
            var productosActivos = _persistencia
                .ObtenerTodos()
                .Where(p => p.IsActive)
                .ToList();

            if (productosActivos.Count == 0)
                return NoContent();

            return Ok(productosActivos);
        }

        [HttpGet("products/{sku}")]
    }
}