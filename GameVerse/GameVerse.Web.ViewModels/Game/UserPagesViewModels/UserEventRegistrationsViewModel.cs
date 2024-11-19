
namespace GameVerse.Web.ViewModels.Game.UserPagesViewModels
{
    public class UserEventRegistrationsViewModel
    {
        public string EventId { get; set; } = null!;

        public string Topic { get; set; } = null!;

        public string Image { get; set; } = null!;

        public string RegistrationDate { get; set; } = null!;

        public string TicketPrice { get; set; } = null!;

        public int TicketQuantity { get; set; }

    }
}
