
namespace GameVerse.Web.ViewModels.ShoppingCart
{
    public class GameCartItemsViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int Quantity { get; set; }

        public string Price { get; set; } = null!;

        public string TotalPrice { get; set; } = null!;

        public string AddedOn { get; set; } = null!;

        public string Image { get; set; } = null!;
    }
}
