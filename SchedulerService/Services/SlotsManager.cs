using Pizza_Cabin_Inc.Assets;
using Pizza_Cabin_Inc.Entities;
using Pizza_Cabin_Inc.HttpUtilities;
using SchedulerService.Services.Interfaces;

namespace SchedulerService.Services
{
    public class SlotsManager : ISlotsManager
    {
        private readonly IExpertAvailableSlots _expertAvailableSlots;
        private readonly IPrinter _printer;

        public SlotsManager(IExpertAvailableSlots expertAvailableSlots, IPrinter printer)
        {
            _expertAvailableSlots = expertAvailableSlots;
            _printer = printer;
        }

        
        public void FindSlots(ScheduleResult scheduleResult, int standupQuorum)
        {
            Dictionary<string, List<Expert>> expertsAvailability = new();
            int absence = 0;
            int teamMembers = scheduleResult.Schedules.Count;

            // Iterate over the schedules
            foreach (Schedule schedule in scheduleResult.Schedules)
            {
                absence = CheckIfWorkingDay(expertsAvailability, absence, schedule);
            }

            _printer.PrintSlotReport(teamMembers, absence, standupQuorum, expertsAvailability);
        }

        private  int CheckIfWorkingDay(Dictionary<string, List<Expert>> expertsAvailability, int absence, Schedule schedule)
        {
            if (!schedule.IsFullDayAbsence && schedule.ContractTimeMinutes > 0)
            {
                // Iterate over the projection entries
                foreach (Projection projection in schedule.Projection)
                {
                    // Check if the projection is not a break or lunch
                    CheckAvailableSlots(expertsAvailability, schedule, projection);
                }
            }
            else
            {
                absence++;
            }
            return absence;
        }

        private  void CheckAvailableSlots(Dictionary<string, List<Expert>> expertsAvailability, Schedule schedule, Projection projection)
        {
            if (projection.Description != WorkDescriptionAssets.Break && projection.Description != WorkDescriptionAssets.Lunch)
            {
                List<string> expertSlots = _expertAvailableSlots.FindExpertSlots(projection.StartDateObject, projection.minutes);

                foreach (string expertSlot in expertSlots)
                {
                    if (!expertsAvailability.ContainsKey(expertSlot))
                    {
                        expertsAvailability[expertSlot] = new List<Expert>();
                    }
                    expertsAvailability[expertSlot].Add(new Expert() { Id = schedule.PersonId, Name = schedule.Name });
                }
            }
        }

       

       
    }
}
