
using GameVerse.Web.ViewModels.Event;

namespace GameVerse.Services.Interfaces.Events
{
    public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> GetAllEventsAsync();

        Task<string> AddEventAsync(EventInputViewModel inputModel, string userId);

        Task<EventInputViewModel?> EditEventGetAsync(string eventId, string userId);

        Task EditEventPostAsync(EventInputViewModel inputModel, string eventId, string userId);

        Task<EventDeleteViewModel?> DeleteEventGetAsync(Guid eventId, Guid useId);

        Task<bool> DeleteEventPostAsync(Guid eventId, Guid userId);

        Task<EventDetailsViewModel> GetEventDetailsByIdAsync(Guid id);

        Task<bool> EventExistByTitle(string Title);

        Task<bool> EventExistById(string id);
    }
}
