namespace GameVerse.Web.Areas.Administrator.Models
{
    public class AdminIndexViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalModerators { get; set; }
        public int TotalAdministrators { get; set; }
        public int TotalEvents { get; set; }
        public int TotalGames { get; set; }
        public int TotalBoughtGames { get; set; }
        public int TotalEventRegistrations { get; set; }
        public IEnumerable<string> RecentLogs { get; set; } = new List<string>();
    }
}
