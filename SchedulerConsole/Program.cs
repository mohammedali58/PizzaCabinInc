using Microsoft.Extensions.DependencyInjection;
using Pizza_Cabin_Inc.Entities;
using SchedulerService.Services;
using SchedulerService.Services.Interfaces;
class Program
{
    static async Task Main()
    {
        ServiceProvider serviceProvider = CreateServiceProvider();

        //do the actual work here
        var inputManager = serviceProvider.GetService<IInputManager>();
        var slotsManager = serviceProvider.GetService<ISlotsManager>();

        // get team schedule result
        Response response = await inputManager.GetTeamScheduleDetails();

        // Number of team members needed for the meeting
        var maximumAllowedNumber = response.ScheduleResult.Schedules.Count;
        int standupQuorum = inputManager.GetstandupMembersCount(maximumAllowedNumber);

        // do the logic here 
        slotsManager.FindSlots(response.ScheduleResult, standupQuorum);

    }

    private static ServiceProvider CreateServiceProvider()
    {
        return new ServiceCollection()
                     .AddScoped<IInputManager, InputManager>()
                     .AddScoped<ISlotsManager, SlotsManager>()
                     .AddScoped<IExpertAvailableSlots, ExpertAvailableSlots>()
                     .AddScoped<IPrinter, Printer>()
                     .BuildServiceProvider();
    }
}
