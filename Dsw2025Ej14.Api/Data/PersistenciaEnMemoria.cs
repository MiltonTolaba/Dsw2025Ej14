using Dsw2025Ej14.Api.Domain;
using System.Text.Json;

namespace Dsw2025Ej14.Api.Data
{
    public class PersistenciaEnMemoria
    {
        private List<Product> _productos;

        public PersistenciaEnMemoria()
        {
            _productos = new List<Product>();
            LoadProducts();
        }
        public List<Product> ObtenerTodos() => _productos;

        public void LoadProducts()
        {
            string json = File.ReadAllText("products.json");
            _productos = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            }) ?? [];
            }
        }
    }
