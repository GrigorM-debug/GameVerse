
namespace GameVerse.Web.ViewModels.Event
{
    public class EventDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Topic { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string EndDate { get; set; } = null!;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Seats { get; set; }

        public string TicketPrice {  get; set; } = null!;

        public string Image {  get; set; } = null!;
    }
}
