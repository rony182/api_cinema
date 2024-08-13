namespace cinema_api.Dtos
{
    public record class FunctionSummaryDto(
        int Id,
        DateOnly Date,
        TimeOnly ScheduleHour,
        float Price,
        string Movie
        );
}
