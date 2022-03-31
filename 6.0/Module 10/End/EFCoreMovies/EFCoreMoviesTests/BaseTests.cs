using AutoMapper;
using EFCoreMovies;
using EFCoreMovies.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMoviesTests
{
    public class BaseTests
    {
        public ApplicationDbContext BuildContext(string nameDB)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(nameDB).Options;
            var dbContext = new ApplicationDbContext(options);
            return dbContext;
        }

        public IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapperProfiles());
            });

            return config.CreateMapper();
        }
    }
}
