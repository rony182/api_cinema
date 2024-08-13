using cinema_api.Dtos;
using cinema_api.Entities;

namespace cinema_api.Mapping
{
    public static class DirectorMapping
    {
        public static DirectorDto ToDto(this Director director)
        {
            return new DirectorDto(director.Id, director.Name);
        }
    }
}
