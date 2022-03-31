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
            context.Logs.Add(new Log { Message = "Executing Get from GenresController" });
            await context.SaveChangesAsync();
            return await context.Genres.AsNoTracking()
                .OrderByDescending(g => EF.Property<DateTime>(g, "CreatedDate"))
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genre>> Get(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(p => p.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            var createdDate = context.Entry(genre).Property<DateTime>("CreatedDate").CurrentValue;

            return Ok(new
            {
                Id = genre.Id,
                Name = genre.Name,
                CreateDate = createdDate
            });
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

            var genreExists = await context.Genres.AnyAsync(p => p.Name == genreCreationDTO.Name);

            if (genreExists)
            {
                return BadRequest($"The genre with name {genreCreationDTO.Name} already exists.");
            }

            var genre = mapper.Map<Genre>(genreCreationDTO);
            context.Add(genre);

            await context.SaveChangesAsync();

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
