
namespace GameVerse.Data.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        //Add properties for Application User

        public DateTime OrderDate { get; set; }

        public int TotalAmount { get; set; }
    }
}
