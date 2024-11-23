namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    /// <summary>
    /// Provides methods for managing and retrieving information about event registrations.
    /// </summary>
    public interface IEventsRegistrationsService
    {
        /// <summary>
        /// Retrieves the total count of event registrations asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
        /// The task result contains the total number of event registrations as an <see cref="int"/>.
        /// </returns>
        Task<int> GetTotalEventsRegistrationsCountAsync();
    }
}
