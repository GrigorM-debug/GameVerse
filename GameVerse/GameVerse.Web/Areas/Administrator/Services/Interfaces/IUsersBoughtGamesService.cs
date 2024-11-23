namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    /// <summary>
    /// Provides methods for managing and retrieving information about games purchased by users.
    /// </summary>
    public interface IUsersBoughtGamesService
    {
        /// <summary>
        /// Retrieves the total count of games purchased by users asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
        /// The task result contains the total number of purchased games as an <see cref="int"/>.
        /// </returns>
        Task<int> GetUsersBoughtGamesCountAsync();
    }
}
