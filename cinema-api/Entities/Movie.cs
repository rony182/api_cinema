namespace cinema_api.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int DirectorId { get; set; }
        public bool IsInternational { get; set; } = false;
        public Director? Director { get; set; }
    }
}
