using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await context.Products.ToListAsync();
        }

        [HttpGet("merch")]
        public async Task<ActionResult<IEnumerable<Merchandising>>> GetMerch()
        {
            return await context.Set<Merchandising>().ToListAsync();
        }

        [HttpGet("rentables")]
        public async Task<ActionResult<IEnumerable<RentableMovie>>> GetRentables()
        {
            return await context.Set<RentableMovie>().ToListAsync();
        }
    }
}
