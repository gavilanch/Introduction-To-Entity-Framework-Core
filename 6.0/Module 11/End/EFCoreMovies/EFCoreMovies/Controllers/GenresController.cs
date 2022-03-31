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
        private readonly ILogger<GenresController> logger;
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;

        public GenresController(ApplicationDbContext context, IMapper mapper, ILogger<GenresController> logger,
            IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
            this.contextFactory = contextFactory;
        }

        [HttpPost("concurrency_token")]
        public async Task<ActionResult> ConcurrencyToken()
        {

            var genreId = 1;

            try
            {
                // Felipe reads a record from the db
                var genre = await context.Genres.FirstOrDefaultAsync(p => p.Id == genreId);
                genre.Name = "Felipe was here 2";

                // Claudia updates the record in the DB
                await context.Database.ExecuteSqlInterpolatedAsync($@"
                UPDATE Genres SET Example = 'Whatever I want 2' 
                WHERE Id = {genreId}");

                // Felipe update the record
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var currentGenre = await context.Genres.AsNoTracking().FirstOrDefaultAsync(p => p.Id == genreId);

                foreach (var property in entry.Metadata.GetProperties())
                {
                    var triedValue = entry.Property(property.Name).CurrentValue;
                    var currentDBValue = context.Entry(currentGenre).Property(property.Name).CurrentValue;
                    var previousValue = entry.Property(property.Name).OriginalValue;

                    if (currentDBValue?.ToString() == triedValue?.ToString())
                    {
                        // This is not the property that changed
                        continue;
                    }

                    logger.LogInformation($"--- Property {property.Name} ---");
                    logger.LogInformation($"--- Tried value {triedValue} ---");
                    logger.LogInformation($"--- Value in the database {currentDBValue} ---");
                    logger.LogInformation($"--- Previous value {previousValue} ---");

                    // do something...
                }
            }

            return BadRequest("The record was updated by somebody else...");

        }

        [HttpGet]
        public async Task<IEnumerable<Genre>> Get()
        {
            using (var newContext = contextFactory.CreateDbContext())
            {
                newContext.Logs.Add(new Log { Message = "Executing Get from GenresController" });
                await newContext.SaveChangesAsync();
                return await newContext.Genres.AsNoTracking()
                    .OrderByDescending(g => EF.Property<DateTime>(g, "CreatedDate"))
                    .ToListAsync();
            }

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
            var periodStart = context.Entry(genre).Property<DateTime>("PeriodStart").CurrentValue;
            var periodEnd = context.Entry(genre).Property<DateTime>("PeriodEnd").CurrentValue;

            return Ok(new
            {
                Id = genre.Id,
                Name = genre.Name,
                CreateDate = createdDate,
                periodStart,
                periodEnd
            });
        }

        [HttpGet("temporalAll/{id:int}")]
        public async Task<ActionResult> GetTemporalAll(int id)
        {
            var genres = await context.Genres.TemporalAll()
                .Select(p =>
                new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd")
                })
                .Where(p => p.Id == id).ToListAsync();

            return Ok(genres);
        }

        [HttpGet("temporalAsOf/{id:int}")]
        public async Task<ActionResult> GetTemporalAsOf(int id, DateTime date)
        {
            var genre = await context.Genres.TemporalAsOf(date)
                .Select(p =>
                new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd")
                })
                .Where(p => p.Id == id).FirstOrDefaultAsync();

            return Ok(genre);
        }

        [HttpGet("TemporalFromTo/{id:int}")]
        public async Task<ActionResult> GetTemporalAll(int id, DateTime from, DateTime to)
        {
            var genres = await context.Genres.TemporalFromTo(from, to)
                .Select(p =>
                new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd")
                })
                .Where(p => p.Id == id).ToListAsync();

            return Ok(genres);
        }

        [HttpGet("TemporalContainedIn/{id:int}")]
        public async Task<ActionResult> GetTemporalContainedIn(int id, DateTime from, DateTime to)
        {
            var genres = await context.Genres.TemporalContainedIn(from, to)
                .Select(p =>
                new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd")
                })
                .Where(p => p.Id == id).ToListAsync();

            return Ok(genres);
        }

        [HttpGet("TemporalBetween/{id:int}")]
        public async Task<ActionResult> GetTemporalBetween(int id, DateTime from, DateTime to)
        {
            var genres = await context.Genres.TemporalBetween(from, to)
                .Select(p =>
                new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd")
                })
                .Where(p => p.Id == id).ToListAsync();

            return Ok(genres);
        }

        [HttpPut("modify_several_times")]
        public async Task<ActionResult> ModifySeveralTimes()
        {
            var genreId = 3;

            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == genreId);

            genre.Name = "Comedy 2";
            await context.SaveChangesAsync();
            await Task.Delay(5000);

            genre.Name = "Comedy 3";
            await context.SaveChangesAsync();
            await Task.Delay(5000);

            genre.Name = "Comedy 4";
            await context.SaveChangesAsync();
            await Task.Delay(5000);

            genre.Name = "Comedy 5";
            await context.SaveChangesAsync();
            await Task.Delay(5000);

            genre.Name = "Comedy 6";
            await context.SaveChangesAsync();
            await Task.Delay(5000);

            genre.Name = "Comedy Current";
            await context.SaveChangesAsync();
            await Task.Delay(5000);

            return Ok();
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

            context.Add(genre); // setting the status of genre to Added.
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
        public async Task<ActionResult> Restore(int id, DateTime date)
        {
            var genre = await context.Genres.TemporalAsOf(date)
                .IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            try
            {
                await context.Database.ExecuteSqlInterpolatedAsync(@$"
                SET IDENTITY_INSERT Genres ON;

                INSERT INTO GENRES (Id, Name)
                VALUES({genre.Id}, {genre.Name})

                SET IDENTITY_INSERT Genres OFF;");
            }
            finally
            {
                await context.Database.ExecuteSqlInterpolatedAsync(@$"SET IDENTITY_INSERT Genres OFF;");
            }

            return Ok();
        }

    }
}
