using Pizza_Cabin_Inc.Assets;
using Pizza_Cabin_Inc.Entities;
using Pizza_Cabin_Inc.HttpUtilities;
using Pizza_Cabin_Inc.Utilities;
using SchedulerService.Services.Interfaces;

namespace SchedulerService.Services
{
    public class InputManager : IInputManager
    {

        public async Task<Response> GetTeamScheduleDetails()
        {
            string apiUrl = ApiAssets.Url;

            string json = await HttpUtility.GetExpertsFromAPI(apiUrl);

            Response response = JsonParser.ParseResponse(json);
            return response;
        }

        public int GetstandupMembersCount(int maximumAllowedNumber)
        {
            int standupQuorum = 0;

            do
            {

                Console.Write("Please Enter a value between 1 and {0}: ", maximumAllowedNumber);
                try
                {
                    standupQuorum = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (standupQuorum < 1 || standupQuorum > maximumAllowedNumber)
                {
                    Console.WriteLine("Invalid value. Please enter a value between 1 and {0}.", maximumAllowedNumber);
                }
            } while (standupQuorum < 1 || standupQuorum > maximumAllowedNumber);
            return standupQuorum;
        }

    }
}
