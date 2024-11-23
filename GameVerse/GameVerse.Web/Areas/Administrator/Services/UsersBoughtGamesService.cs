using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Web.Areas.Administrator.Services
{
    public class UsersBoughtGamesService(
        IGenericRepository<UserBoughtGame, object> usersBoughtGamesRepository
        ) : IUsersBoughtGamesService
    {
        private readonly IGenericRepository<UserBoughtGame, object> _usersBoughtGamesRepository =
            usersBoughtGamesRepository;

        public async Task<int> GetUsersBoughtGamesCountAsync()
        {
            int usersBoughtGamesCount = await _usersBoughtGamesRepository
                .AllAsReadOnly()
                .CountAsync();

            return usersBoughtGamesCount;
        }
    }
}
