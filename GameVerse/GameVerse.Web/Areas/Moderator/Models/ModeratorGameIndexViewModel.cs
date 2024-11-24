namespace GameVerse.Web.Areas.Moderator.Models
{
    public class ModeratorGameIndexViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string Price { get; set; } = null!;

        public int QuantityInStock { get; set; }
    }
}
