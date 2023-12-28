using SmapleWebAPI.Model;

namespace SmapleWebAPI.Services
{
    public interface IProductService
    {
        public List<Product> GetALlProducts();

        public Product GetProductsById(int Id);
    }
}
