namespace Pizza_Cabin_Inc.Utilities
{
    public static class DateConversion
    {
        public static DateTime ConvertDate(string dateString)
        {
            long ms1 = long.Parse(dateString.Substring(6, 13));
           return new DateTime(ms1 * 10000, DateTimeKind.Utc);
        }
    }
}
