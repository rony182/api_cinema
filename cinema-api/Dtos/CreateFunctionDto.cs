using System.ComponentModel.DataAnnotations;

namespace cinema_api.Dtos
{
    public record class CreateFunctionDto(
        [Required] DateOnly Date,
        [Required] TimeOnly ScheduleHour,
        [Required] float Price,
        [Required] int MovieId
        );
}
