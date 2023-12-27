using log4net.Config;
using log4net.Core;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmapleWebAPI.Data;
using SmapleWebAPI.Model;
using SmapleWebAPI.Repository;
using System.Reflection;

namespace SmapleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository context)
        {
            _productRepository = context;
        }

        // GET: api/Products
        [HttpGet]
        public  ActionResult<IEnumerable<Product>> GetProduct()
        {
            try
            {
                if (_productRepository! == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                
            }
            return  _productRepository.GetALlProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepository.GetProductsById(id);
            if (product == null)
                return NotFound();

            return product;
        }

        //// PUT: api/Products/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Products
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    if (_context.Product == null)
        //    {
        //        return Problem("Entity set 'ProductAPIContext.Product'  is null.");
        //    }
        //    _context.Product.Add(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        //}

        //// DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    if (_context.Product == null)
        //    {
        //        return NotFound();
        //    }
        //    var product = await _context.Product.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Product.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProductExists(int id)
        //{
        //    return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
        private void LogError(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
            _logger.Info(message);
        }
    }

}
