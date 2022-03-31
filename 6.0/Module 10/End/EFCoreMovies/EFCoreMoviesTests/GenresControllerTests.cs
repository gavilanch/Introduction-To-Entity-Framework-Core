using EFCoreMovies.Controllers;
using EFCoreMovies.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMoviesTests
{
    [TestClass]
    public class GenresControllerTests: BaseTests
    {
        [TestMethod]
        public async Task Post_IfISendAGenre_ThenTheGenreIsInsertedInTheDB()
        {
            // Preparation
            var nameDB = Guid.NewGuid().ToString();
            var context1 = BuildContext(nameDB);
            var mapper = ConfigureAutoMapper();
            var genresController = new GenresController(context1, mapper, logger: null);
            var genreCreationDTO = new GenreCreationDTO { Name = "genre 1" };

            // Testing
            await genresController.Post(genreCreationDTO);

            // Verification
            var context2 = BuildContext(nameDB);
            var genre = await context2.Genres.SingleAsync();
            Assert.AreEqual(1, genre.Id);
            Assert.AreEqual("genre 1", genre.Name);
        }

        [TestMethod]
        public async Task Post_IfISendAGenreWithARepeatedName_ThenWeGetA400Error()
        {
            // Preparation
            var nameDB = Guid.NewGuid().ToString();
            var context1 = BuildContext(nameDB);
            var mapper = ConfigureAutoMapper();
            var genresController = new GenresController(context1, mapper, logger: null);
            var genreCreationDTO = new GenreCreationDTO { Name = "genre 1" };

            var context2 = BuildContext(nameDB);
            context2.Genres.Add(new EFCoreMovies.Entities.Genre { Name = "genre 1" });
            await context2.SaveChangesAsync();

            // Testing
            var response = await genresController.Post(genreCreationDTO);

            // Verification
            var objectResult = response as BadRequestObjectResult;
            Assert.IsNotNull(objectResult);
            Assert.AreEqual("The genre with name genre 1 already exists.", objectResult.Value);
        }
    }
}
