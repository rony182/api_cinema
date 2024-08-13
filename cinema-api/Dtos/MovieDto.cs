namespace cinema_api.Dtos
{
    public record class MovieDto(
        int Id, 
        string Title,
        int DirectorId,
        bool IsInternational
        );
}
