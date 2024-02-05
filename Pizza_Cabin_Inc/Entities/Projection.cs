namespace Pizza_Cabin_Inc.Entities
{
    public class Projection
    {
        public string Color { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Start { get; set; }

        public DateTime StartDateObject { get; set; }
        public int minutes { get; set; }
    }
}
