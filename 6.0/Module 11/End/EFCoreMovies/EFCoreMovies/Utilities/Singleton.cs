using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Utilities
{
    public class Singleton
    {
        private readonly IServiceProvider serviceProvider;

        public Singleton(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            await using (var scope = serviceProvider.CreateAsyncScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                return await context.Genres.ToListAsync();
            }
        }
    }
}
