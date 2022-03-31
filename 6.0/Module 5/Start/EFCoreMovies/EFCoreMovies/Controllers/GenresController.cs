using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreMovies.Utilities;
using EFCoreMovies.DTOs;
using AutoMapper;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Genre>> Get()
        {
            return await context.Genres.AsNoTracking()
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        [HttpPost("add2")]
        public async Task<ActionResult> Add2(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(p => p.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.Name += " 2";
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post(GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            var status1 = context.Entry(genre).State;
            context.Add(genre); // marking genre as added.
            var status2 = context.Entry(genre).State;

            await context.SaveChangesAsync();
            var status3 = context.Entry(genre).State;

            return Ok();
        }

        [HttpPost("several")]
        public async Task<ActionResult> Post(GenreCreationDTO[] genresDTO)
        {
            var genres = mapper.Map<Genre[]>(genresDTO);
            context.AddRange(genres);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(p => p.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            context.Remove(genre);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("softdelete/{id:int}")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(p => p.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.IsDeleted = true;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("restore/{id:int}")]
        public async Task<ActionResult> Restore(int id)
        {
            var genre = await context.Genres.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.IsDeleted = false;
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
