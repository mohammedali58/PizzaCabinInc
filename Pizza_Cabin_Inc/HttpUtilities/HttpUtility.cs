namespace Pizza_Cabin_Inc.HttpUtilities
{
    public static class HttpUtility
    {
        public static async Task<string> GetExpertsFromAPI(string url)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }
    }
}
