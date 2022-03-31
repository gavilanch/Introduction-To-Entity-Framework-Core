namespace EFCoreMovies.Utilities
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, int recordsToTake)
        {
            return source.Skip((page - 1) * recordsToTake).Take(recordsToTake);
        }
    }
}
