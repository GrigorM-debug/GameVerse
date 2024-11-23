using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Web.Areas.Administrator.Services
{
    /// <summary>
    /// Service for managing and retrieving data about games purchased by users.
    /// </summary>
    public class UsersBoughtGamesService(
        IGenericRepository<UserBoughtGame, object> usersBoughtGamesRepository
        ) : IUsersBoughtGamesService
    {
        private readonly IGenericRepository<UserBoughtGame, object> _usersBoughtGamesRepository =
            usersBoughtGamesRepository;

        /// <summary>
        /// Retrieves the total count of games purchased by users asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
        /// The task result contains the total number of purchased games as an <see cref="int"/>.
        /// </returns>
        public async Task<int> GetUsersBoughtGamesCountAsync()
        {
            int usersBoughtGamesCount = await _usersBoughtGamesRepository
                .AllAsReadOnly()
                .CountAsync();

            return usersBoughtGamesCount;
        }
    }
}
