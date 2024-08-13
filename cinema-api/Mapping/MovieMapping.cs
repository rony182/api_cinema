using cinema_api.Dtos;
using cinema_api.Entities;

namespace cinema_api.Mapping
{
    public static class MovieMapping
    {
        public static MovieDto ToDto(this Movie movie)
        {
            return new MovieDto(movie.Id, movie.Title, movie.DirectorId, movie.IsInternational);
        }
    }
}
