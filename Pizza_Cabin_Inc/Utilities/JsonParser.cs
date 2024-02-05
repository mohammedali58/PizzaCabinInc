using Pizza_Cabin_Inc.Entities;
using System.Text.Json;

namespace Pizza_Cabin_Inc.Utilities
{
    public static class JsonParser
    {
        public static Response ParseResponse(string json)
        {
            JsonSerializerOptions options = new();

            Response response = JsonSerializer.Deserialize<Response>(json, options);

            foreach (Schedule schedule in response.ScheduleResult.Schedules)
            {
                schedule.DateObject = DateConversion.ConvertDate(schedule.Date);

                foreach (Projection projection in schedule.Projection)
                {
                    projection.StartDateObject = DateConversion.ConvertDate(projection.Start);
                }
            }

            return response;
        }
    }
}
