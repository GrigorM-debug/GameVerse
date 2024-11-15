
namespace GameVerse.Web.ViewModels.ShoppingCart
{
    public class EventCartItemsViewModel
    {
        public string Id { get; set; } = null!;

        public string Topic { get; set; } = null!;

        public int TicketQuantity { get; set; }

        public string TicketPrice { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public string AddedOn { get; set; } = null!;
    }
}
