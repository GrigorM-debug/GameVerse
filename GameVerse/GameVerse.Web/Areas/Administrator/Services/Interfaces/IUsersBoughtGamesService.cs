namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    public interface IUsersBoughtGamesService
    {
        Task<int> GetUsersBoughtGamesCountAsync();
    }
}
