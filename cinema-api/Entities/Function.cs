namespace cinema_api.Entities
{
    public class Function
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly ScheduleHour { get; set; }
        public float Price { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
