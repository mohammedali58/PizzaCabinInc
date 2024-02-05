using Pizza_Cabin_Inc.Assets;
using Pizza_Cabin_Inc.Entities;

namespace Pizza_Cabin_Inc.Utilities
{
    public static class SlotsManager
    {
        public static void FindSlots(ScheduleResult scheduleResult, int standupQuorum)
        {
            Dictionary<string, List<Expert>> expertsAvailability = new();
            int absence = 0;
            int teamMembers = scheduleResult.Schedules.Count;

            // Iterate over the schedules
            foreach (Schedule schedule in scheduleResult.Schedules)
            {
                absence = CheckIfWorkingDay(expertsAvailability, absence, schedule);
            }

            PrintSlotReport(teamMembers,absence, standupQuorum, expertsAvailability);
        }

        private static int CheckIfWorkingDay(Dictionary<string, List<Expert>> expertsAvailability, int absence, Schedule schedule)
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

        private static void CheckAvailableSlots(Dictionary<string, List<Expert>> expertsAvailability, Schedule schedule, Projection projection)
        {
            if (projection.Description != WorkDescriptionAssets.Break && projection.Description != WorkDescriptionAssets.Lunch)
            {
                List<string> expertSlots = ExpertAvailableSlots.FindExpertSlots(projection.StartDateObject, projection.minutes);

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

        public static void PrintSlotReport(int teamMembers,int absence, int standupQuorum, Dictionary<string, List<Expert>> slots)
        {
            int existingTeamMembers = teamMembers - absence;
            bool canHoldStandUp = false;

            foreach (var key in slots.Keys)
            {
                if (slots[key].Count >= standupQuorum && standupQuorum < existingTeamMembers)
                {
                    Console.WriteLine($"StandUp can be hold at {key} with {standupQuorum} employees from the following");
                    Console.WriteLine("Members");
                    foreach (var expert in slots[key])
                    {
                        Console.WriteLine($"{expert.Id}: {expert.Name}");
                    }
                    Console.WriteLine("=================================");
                    canHoldStandUp = true;
                    
                }

            }

            if(!canHoldStandUp)
            {
                Console.WriteLine("can not find an appropriate time for this Standup Quorum");
            }
        }
        
    }
}
