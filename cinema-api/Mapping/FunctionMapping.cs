using cinema_api.Dtos;
using cinema_api.Entities;

namespace cinema_api.Mapping
{
    public static class FunctionMapping
    {
        public static Function ToEntity(this CreateFunctionDto function)
        {
            return new Function()
            {
                Date = function.Date,
                ScheduleHour = function.ScheduleHour,
                Price = function.Price,
                MovieId = function.MovieId,
            };
        }
        public static Function ToEntity(this UpdateFunctionDto function, int id)
        {
            return new Function()
            {
                Id = id,
                Date = function.Date,
                ScheduleHour = function.ScheduleHour,
                Price = function.Price,
                MovieId = function.MovieId,
            };
        }

        public static FunctionSummaryDto ToFunctionSummaryDto(this Function function)
        {
            return new(
                    function.Id,
                    function.Date,
                    function.ScheduleHour,
                    function.Price,
                    function.Movie!.Title
                );
        }

        public static FunctionDetailsDto ToFunctionDetailsDto(this Function function)
        {
            return new(
                    function.Id,
                    function.Date,
                    function.ScheduleHour,
                    function.Price,
                    function.MovieId
                );
        }
    }
}
