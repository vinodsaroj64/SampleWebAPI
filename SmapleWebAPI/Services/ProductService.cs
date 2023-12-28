using SmapleWebAPI.Model;
using SmapleWebAPI.Repository;

namespace SmapleWebAPI.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }
        public List<Product> GetALlProducts()
        {
            return _productRepository.GetALlProducts();
        }

        public Product GetProductsById(int Id) { 
            return _productRepository.GetProductsById(Id);
        }
    }
}
