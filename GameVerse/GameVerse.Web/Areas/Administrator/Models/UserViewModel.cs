namespace GameVerse.Web.Areas.Administrator.Models
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public List<string> Roles { get; set; }

        public int TotalEventsCreated { get; set; }

        public int TotalGamesCreated { get; set; }
    }
}
