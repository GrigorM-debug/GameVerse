﻿
using GameVerse.Web.ViewModels.Event;

namespace GameVerse.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> GetAllEventsAsync();

        Task<string> AddEventAsync(EventInputViewModel inputModel, string userId);

        Task<EventInputViewModel?> EditEventGetAsync(string eventId, string userId);

        Task EditEventPostAsync(EventInputViewModel inputModel, string eventId, string userId);

        Task<EventDeleteViewModel?> DeleteEventGetAsync(string eventId, string useId);

        Task DeleteEventPostAsync(string eventId, string userId);

        Task<EventDetailsViewModel> GetEventDetailsByIdAsync(string id);

        Task<bool> EventExistByTitle(string Title);

        Task<bool> EventExistById(string id);
    }
}
