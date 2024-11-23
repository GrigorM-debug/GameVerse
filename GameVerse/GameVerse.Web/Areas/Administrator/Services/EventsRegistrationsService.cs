using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Web.Areas.Administrator.Services
{
    /// <summary>
    /// Service for managing event registrations and retrieving related data.
    /// </summary>
    /// <param name="eventsRegistrationsRepository">
    /// A repository for accessing event registration data.
    /// </param>
    public class EventsRegistrationsService(
        IGenericRepository<EventRegistration, object> eventsRegistrationsRepository
        ) : IEventsRegistrationsService
    {
        private readonly IGenericRepository<EventRegistration, object> _eventsRegistrationsRepository = eventsRegistrationsRepository;

        /// <summary>
        /// Retrieves the total count of event registrations asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
        /// The task result contains the total number of event registrations as an <see cref="int"/>.
        /// </returns>
        public async Task<int> GetTotalEventsRegistrationsCountAsync()
        {
            int eventsRegistrationsTotalCount = await _eventsRegistrationsRepository
                .AllAsReadOnly()
                .CountAsync();

            return eventsRegistrationsTotalCount;
        }
    }
}
