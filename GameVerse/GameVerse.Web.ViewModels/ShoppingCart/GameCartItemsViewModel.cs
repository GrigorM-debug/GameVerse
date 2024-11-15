
namespace GameVerse.Web.ViewModels.ShoppingCart
{
    public class GameCartItemsViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int Quantity { get; set; }

        public string Price { get; set; } = null!;

        public decimal TotalPrice { get; set; } 

        public string AddedOn { get; set; } = null!;
    }
}
