using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    public class CinemasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CinemasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CinemaDTO>> Get()
        {
            return await context.Cinemas.ProjectTo<CinemaDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("closetome")]
        public async Task<ActionResult> Get(double latitude, double longitude)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var myLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));

            var maxDistanceInMeters = 2000; // 2 kms

            var cinemas = await context.Cinemas
                .OrderBy(c => c.Location.Distance(myLocation))
                .Where(c => c.Location.IsWithinDistance(myLocation, maxDistanceInMeters))
                .Select(c => new
                {
                    Name = c.Name,
                    Distance = Math.Round(c.Location.Distance(myLocation))
                }).ToListAsync();

            return Ok(cinemas);
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var cinemaLocation = geometryFactory.CreatePoint(new Coordinate(-69.913539, 18.476256));

            var cinema = new Cinema()
            {
                Name = "My cinema",
                Location = cinemaLocation,
                CinemaOffer = new CinemaOffer()
                {
                    DiscountPercentage = 5,
                    Begin = DateTime.Today,
                    End = DateTime.Today.AddDays(7)
                },
                CinemaHalls = new HashSet<CinemaHall>()
                {
                    new CinemaHall()
                    {
                        Cost = 200,
                        CinemaHallType = CinemaHallType.TwoDimensions
                    },
                     new CinemaHall()
                    {
                        Cost = 250,
                        CinemaHallType = CinemaHallType.ThreeDimensions
                    }
                }
            };

            context.Add(cinema);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("withDTO")]
        public async Task<ActionResult> Post(CinemaCreationDTO cinemaCreationDTO)
        {
            var cinema = mapper.Map<Cinema>(cinemaCreationDTO);
            context.Add(cinema);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("cinemaOffer")]
        public async Task<ActionResult> PutCinemaOffer(CinemaOffer cinemaOffer)
        {
            context.Update(cinemaOffer);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var cinemaDB = await context.Cinemas
               .Include(c => c.CinemaHalls)
               .Include(c => c.CinemaOffer)
               .FirstOrDefaultAsync(c => c.Id == id);

            if (cinemaDB is null)
            {
                return NotFound();
            }

            cinemaDB.Location = null;

            return Ok(cinemaDB);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CinemaCreationDTO cinemaCreationDTO, int id)
        {
            var cinemaDB = await context.Cinemas
                .Include(c => c.CinemaHalls)
                .Include(c => c.CinemaOffer)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cinemaDB is null)
            {
                return NotFound();
            }

            cinemaDB = mapper.Map(cinemaCreationDTO, cinemaDB);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
