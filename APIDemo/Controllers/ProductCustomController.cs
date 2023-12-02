using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;


        public ProductCustomController(InvoiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public List<Product> GetProductsWithCategory(string categoryName)
        {

            var response=_context.Products.Include(x => x.Category).
                Where(x => x.Category.Name.Contains(categoryName)).
                OrderByDescending(x => x.Name)
                .ToList();

            return response;

        }



        [HttpGet]
        public  List<Product>GetProductsPrice(double price)
        {
            var response= _context.Products.Where(x=>x.Price> price).ToList();

            return response;
        }

        [HttpGet]
        public Product GetProductPrice(double price) 
        {
            var response = _context.Products
                .Where(x => x.Price > price).FirstOrDefault();
            return response;
        }



        [HttpPost]
        public void Insert(List<ProductV1> request)
        {
            List<Product> products = new List<Product>();
            
            foreach (var item in request)
            {
                Product product = new Product
                {
                    Price = item.Price,
                    Name = item.Name,
                    Active = true
                };
                products.Add(product);
            }
            _context.Products.AddRange(products);
            _context.SaveChanges();          
        }   
    }
}