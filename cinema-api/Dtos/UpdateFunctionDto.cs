using System.ComponentModel.DataAnnotations;

namespace cinema_api.Dtos
{
    public record class UpdateFunctionDto(
        [Required] DateOnly Date,
        [Required] TimeOnly ScheduleHour,
        [Required] float Price,
        int MovieId
        );
}
