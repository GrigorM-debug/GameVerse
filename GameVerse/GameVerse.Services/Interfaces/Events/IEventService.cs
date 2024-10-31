
using GameVerse.Web.ViewModels.Event;

namespace GameVerse.Services.Interfaces.Events
{
    public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> GetAllEventsAsync();

        Task<bool> AddEventAsync(EventInputViewModel inputModel, Guid userId);

        Task<EventDetailsViewModel> GetEventDetailsByIdAsync(Guid id);

        Task<bool> EventExistByTitle(string Title);
    }
}
