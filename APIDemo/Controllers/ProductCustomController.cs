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
    }
}