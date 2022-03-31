using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreMovies.Utilities;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genre>> Get(int page = 1, int recordsToTake = 2)
        {
            return await context.Genres.AsNoTracking()
                .OrderBy(g => g.Name)
                .Paginate(page, recordsToTake)
                .ToListAsync();
        }

        [HttpGet("first")]
        public async Task<ActionResult<Genre>> GetFirst()
        {
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.Name.Contains("z"));

            if (genre is null)
            {
                return NotFound();
            }

            return genre;
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<Genre>> Filter(string name)
        {
            return await context.Genres.Where(g => g.Name.Contains(name)).ToListAsync();
        }
    }
}
