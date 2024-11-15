
namespace GameVerse.Web.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<GameCartItemsViewModel> GameCartItems { get; set; } = new HashSet<GameCartItemsViewModel>();

        public IEnumerable<EventCartItemsViewModel> EventCartItems { get; set; } =
            new HashSet<EventCartItemsViewModel>();

        public string TotalPrice { get; set; } = null!;

    }
}
