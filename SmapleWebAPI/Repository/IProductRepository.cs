using SmapleWebAPI.Model;

namespace SmapleWebAPI.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetALlProducts();

        public Product GetProductsById(int Id);
    }
}
