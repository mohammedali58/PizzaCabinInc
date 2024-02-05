using Pizza_Cabin_Inc.Assets;
using Pizza_Cabin_Inc.Entities;
using Pizza_Cabin_Inc.HttpUtilities;
using SchedulerService.Services.Interfaces;

namespace SchedulerService.Services
{
    public class Printer : IPrinter
    {
     
        public void PrintSlotReport(int teamMembers, int absence, int standupQuorum, Dictionary<string, List<Expert>> slots)
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

            if (!canHoldStandUp)
            {
                Console.WriteLine("can not find an appropriate time for this Standup Quorum");
            }
        }

       
    }
}
