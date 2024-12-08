namespace GameVerse.Web.Areas.Administrator.Models
{
    public class UserEventRegistrationInfoViewModel
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public string EventTopic { get; set; } = null!;

        public int NumberOfTickets { get; set; }

        public string PricePaid { get; set; } = null!;

        public string RegistrationDate { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string EndDate { get; set; } = null!;
    }
}
