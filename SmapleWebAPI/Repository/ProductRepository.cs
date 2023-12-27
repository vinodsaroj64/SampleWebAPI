using SmapleWebAPI.Data;
using SmapleWebAPI.Model;

namespace SmapleWebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        public readonly ProductAPIContext context;
        public ProductRepository(ProductAPIContext _context) { 
        context = _context;
        }
        public List<Product> GetALlProducts()
        {
            return context.Product.ToList();
        }

        public Product GetProductsById(int Id)
        {
            return context.Product.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
