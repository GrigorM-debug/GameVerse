
namespace GameVerse.Web.ViewModels.Game
{
    public class GameIndexViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string Image {  get; set; } = null!;

        public int QuantityInStock { get; set; }

        public string Publisher { get; set; } = null!;
    }
}
