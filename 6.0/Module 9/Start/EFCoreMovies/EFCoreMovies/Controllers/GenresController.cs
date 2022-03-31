using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreMovies.Utilities;
using EFCoreMovies.DTOs;
using AutoMapper;
using Microsoft.Data.SqlClient;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("stored_procedure/{id:int}")]
        public async Task<ActionResult<Genre>> GetSP(int id)
        {
            var genres = context.Genres.FromSqlInterpolated($"EXEC Genres_GetById {id}")
                .IgnoreQueryFilters().AsAsyncEnumerable();

            await foreach (var genre in genres)
            {
                return genre;
            }

            return NotFound();

        }

        [HttpPost("stored_procedure")]
        public async Task<ActionResult> PostSP(GenreCreationDTO genreCreationDTO)
        {
            var genreExists = await context.Genres.AnyAsync(p => p.Name == genreCreationDTO.Name);

            if (genreExists)
            {
                return BadRequest($"The genre with name {genreCreationDTO.Name} already exists.");
            }

            var output = new SqlParameter();
            output.ParameterName = "@id";
            output.SqlDbType = System.Data.SqlDbType.Int;
            output.Direction = System.Data.ParameterDirection.Output;

            await context.Database.ExecuteSqlRawAsync("EXEC Genres_Insert @name = {0}, @id = {1} OUTPUT", 
                    genreCreationDTO.Name, output);

            var id = (int)output.Value;

            return Ok(id);
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

            //var genre = await context.Genres.FromSqlInterpolated($"SeLeCt * FROM Genres WHERE Id = {id}")
            //    .IgnoreQueryFilters().FirstOrDefaultAsync(); 

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

            //context.Add(genre); // setting the status of genre to Added.
            //context.Entry(genre).State = EntityState.Added;

            await context.Database.ExecuteSqlInterpolatedAsync($@"
                                                    INSERT INTO Genres(Name)
                                                    VALUES({genre.Name})");

            //await context.SaveChangesAsync();

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

        [HttpPut]
        public async Task<ActionResult> Put(Genre genre)
        {
            context.Update(genre);
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
