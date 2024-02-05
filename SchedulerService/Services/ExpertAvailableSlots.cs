using Pizza_Cabin_Inc.Assets;
using Pizza_Cabin_Inc.Entities;
using SchedulerService.Services.Interfaces;

namespace SchedulerService.Services
{
    public class ExpertAvailableSlots : IExpertAvailableSlots
    {
        public  List<string> FindExpertSlots(DateTime startTime, int duration)
        {
            List<string> availableSlots = new();
            int iterations = duration / WorkDescriptionAssets.StandupDuration - 1;
            DateTime iterationTime = startTime;
            DateTime endTime = startTime.AddMinutes(duration);

            for (int i = 0; i <= iterations; i++)
            {
                if (iterationTime.Minute % WorkDescriptionAssets.StandupDuration == 0 &&
                    iterationTime.AddMinutes(WorkDescriptionAssets.StandupDuration) < endTime)
                {
                    availableSlots.Add($"{iterationTime.Hour}:{iterationTime.Minute}");
                    iterationTime = iterationTime.AddMinutes(WorkDescriptionAssets.StandupDuration);
                }
                else
                {
                    iterationTime = iterationTime.AddMinutes(WorkDescriptionAssets.StandupDuration - iterationTime.Minute);

                }

            }
            return availableSlots;
        }
    }
}
