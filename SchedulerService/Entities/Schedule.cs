namespace Pizza_Cabin_Inc.Entities
{
   public class Schedule
    {
        public int ContractTimeMinutes { get; set; }

        public string Date { get; set; }

        public DateTime DateObject { get; set; }

        public bool IsFullDayAbsence { get; set; }

        public string Name { get; set; } = string.Empty;

        public Guid PersonId { get; set; }

        public List<Projection> Projection { get; set; } = [];
    }
}
