using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Web.Areas.Administrator.Services
{
    public class EventsRegistrationsService(
        IGenericRepository<EventRegistration, object> eventsRegistrationsRepository
        ) : IEventsRegistrationsService
    {
        private readonly IGenericRepository<EventRegistration, object> _eventsRegistrationsRepository = eventsRegistrationsRepository;

        public async Task<int> GetTotalEventsRegistrationsCountAsync()
        {
            int eventsRegistrationsTotalCount = await _eventsRegistrationsRepository
                .AllAsReadOnly()
                .CountAsync();

            return eventsRegistrationsTotalCount;
        }
    }
}
