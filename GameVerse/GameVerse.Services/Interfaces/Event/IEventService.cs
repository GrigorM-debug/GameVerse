
using GameVerse.Web.ViewModels.Event;

namespace GameVerse.Services.Interfaces.Event
{
    public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> GetAllEventsAsync();

        Task<bool> AddEventAsync(EventIndexViewModel inputModel);

        Task<EventDetailsViewModel> GetEventDetailsByIdAsync(Guid id);
    }
}
