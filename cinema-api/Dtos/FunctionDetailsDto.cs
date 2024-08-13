namespace cinema_api.Dtos
{
    public record class FunctionDetailsDto(
        int Id,
        DateOnly Date,
        TimeOnly ScheduleHour,
        float Price,
        int MovieId
        );
}
