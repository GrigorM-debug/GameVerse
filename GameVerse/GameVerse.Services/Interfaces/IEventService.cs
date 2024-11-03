
using GameVerse.Web.ViewModels.Event;

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Defines methods for managing events, including adding, editing, deleting, and retrieving event details.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Retrieves all events that are not marked as deleted.
        /// </summary>
        /// <param name="currentPage">The current page</param>
        /// <param name="eventsPerPage">The Events per Page. For example 10</param>
        /// <returns>A collection of <see cref="EventIndexViewModel"/> representing each event.</returns>
        Task<IEnumerable<EventIndexViewModel>> GetAllEventsAsync(int currentPage, int eventsPerPage);

        /// <summary>
        /// Retrieves the total count of the events that are not deleted.
        /// </summary>
        /// <returns>A number of <see cref="int"/> representing events count.</returns>
        Task<int> GetTotalEventsCountAsync();

        /// <summary>
        /// Retrieves last 3 added events that are not marked as deleted.
        /// </summary>
        /// <returns>A collection of <see cref="EventIndexViewModel"/> representing each event.</returns>
        Task<IEnumerable<EventIndexViewModel>> GetLatest3EventsAsync();

        /// <summary>
        /// Adds a new event.
        /// </summary>
        /// <param name="inputModel">The input model containing event details.</param>
        /// <param name="moderatorId">The ID of the moderator creating the event.</param>
        /// <param name="startDate">The start date of the event.</param>
        /// <param name="endDate">The end date of the event.</param>
        /// <returns>The ID of the newly created event as a string.</returns>
        Task<string> AddEventAsync(EventInputViewModel inputModel, string moderatorId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Retrieves an event for editing.
        /// </summary>
        /// <param name="eventId">The ID of the event to retrieve for editing.</param>
        /// <param name="moderatorId">The ID of the moderator requesting to edit.</param>
        /// <returns>An <see cref="EventInputViewModel"/> with event details if found; otherwise, <c>null</c>.</returns>
        Task<EventInputViewModel?> EditEventGetAsync(string eventId, string moderatorId);

        /// <summary>
        /// Updates an event in the repository.
        /// </summary>
        /// <param name="inputModel">The input model containing updated event details.</param>
        /// <param name="eventId">The ID of the event to update.</param>
        /// <param name="moderatorId">The ID of the moderator performing the update.</param>
        /// <param name="startDate">The new start date of the event.</param>
        /// <param name="endDate">The new end date of the event.</param>
        /// <returns>The ID of the updated event as a string.</returns>
        Task<string> EditEventPostAsync(EventInputViewModel inputModel, string eventId, string moderatorId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Retrieves an event for deletion confirmation.
        /// </summary>
        /// <param name="eventId">The ID of the event to retrieve.</param>
        /// <param name="moderatorId">The ID of the moderator requesting deletion.</param>
        /// <returns>A <see cref="EventDeleteViewModel"/> with event details if found; otherwise, <c>null</c>.</returns>
        Task<EventDeleteViewModel?> DeleteEventGetAsync(string eventId, string moderatorId);

        /// <summary>
        /// Marks an event as deleted in the repository.
        /// </summary>
        /// <param name="eventId">The ID of the event to delete.</param>
        /// <param name="userId">The ID of the user performing the deletion.</param>
        Task DeleteEventPostAsync(string eventId, string userId);

        /// <summary>
        /// Retrieves detailed information for a specific event by its ID.
        /// </summary>
        /// <param name="id">The ID of the event to retrieve.</param>
        /// <returns>An <see cref="EventDetailsViewModel"/> with detailed event information.</returns>
        Task<EventDetailsViewModel> GetEventDetailsByIdAsync(string id);

        /// <summary>
        /// Checks if an event with the specified topic already exists.
        /// </summary>
        /// <param name="Title">The title of the event to check.</param>
        /// <returns><c>true</c> if an event with the title exists and is not marked as deleted; otherwise, <c>false</c>.</returns>
        Task<bool> EventExistByTitle(string Title);

        /// <summary>
        /// Checks if an event with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the event to check.</param>
        /// <returns><c>true</c> if the event exists and is not marked as deleted; otherwise, <c>false</c>.</returns>
        Task<bool> EventExistById(string id);

        /// <summary>
        /// Checks if a specific event has a publisher with the given moderator ID.
        /// </summary>
        /// <param name="moderatorId">The ID of the moderator.</param>
        /// <param name="eventId">The ID of the event to check.</param>
        /// <returns><c>true</c> if the event is associated with the specified moderator; otherwise, <c>false</c>.</returns>
        Task<bool> HasPublisherWithIdAsync(string moderatorId, string eventId);
    }
}
