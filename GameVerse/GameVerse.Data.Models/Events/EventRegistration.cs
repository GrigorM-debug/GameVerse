namespace GameVerse.Data.Models.Events
{
    public class EventRegistration
    {
        public Guid EventId { get; set; }

        public Event Event { get; set; } = null!;

        //Add Application User properties

        public DateTime RegistrationDate { get; set; }
    }
}
