using Dsw2025Ej14.Api.Domain;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;


namespace Dsw2025Ej14.Api.Data
{


    public class PersistenciaEnMemoria : IPersistencia
    {
        private List<Product> _productos;

        public PersistenciaEnMemoria()
        {
            _productos = LoadProducts().Result;
        }
        public List<Product> ObtenerProductos() => _productos;

        private async Task<List<Product>> LoadProducts()
        {
            var json = await File.ReadAllTextAsync("products.json");
            return _productos = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions()) ?? new List<Product>();
            
        }
    }
}
