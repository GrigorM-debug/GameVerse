﻿using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Services
{
    /// <summary>
    /// Provides methods for managing events, including adding, editing, deleting, and retrieving event details.
    /// </summary>
    public class EventService(IGenericRepository<Event, Guid> eventRepository) : BaseService, IEventService
    {
        /// <summary>
        /// Injection the Generic Repository using Primary Constructor
        /// </summary>
        /// <param name="eventRepository">The repository used for data access operations on <see cref="Event"/> entities.</param>
        private readonly IGenericRepository<Event, Guid> _eventRepository = eventRepository;

        public async Task<IEnumerable<EventIndexViewModel>> GetLatest3EventsAsync()
        {
            IEnumerable<Event> events = await _eventRepository.GetWithIncludeAsync(e => e.Publisher.User);

            IEnumerable<EventIndexViewModel> eventIndexViewModels = events
                .Where(e => e.IsDeleted == false)
                .OrderBy(e => e.Id)
                .Take(3)
                .Select(e => new EventIndexViewModel
                {
                    Id = e.Id.ToString(),
                    Topic = e.Topic,
                    StartDate = e.StartDate.ToString(EventConstants.EventDateTimeFormat),
                    EndDate = e.EndDate.ToString(EventConstants.EventDateTimeFormat),
                    Seats = e.Seats,
                    TicketPrice = e.TicketPrice.ToString("C"),
                    Image = e.Image,
                    PublisherName = e.Publisher.User.UserName
                });

            return eventIndexViewModels;
        }

        /// <summary>
        /// Adds a new event to the repository.
        /// </summary>
        /// <param name="inputModel">The input model containing event details.</param>
        /// <param name="moderatorId">The ID of the moderator creating the event.</param>
        /// <param name="startDate">The start date of the event.</param>
        /// <param name="endDate">The end date of the event.</param>
        /// <returns>The ID of the newly created event as a string.</returns>
        public async Task<string> AddEventAsync(EventInputViewModel inputModel, string moderatorId, DateTime startDate, DateTime endDate)
        {
            Event newEvent = new Event()
            {
                Topic = inputModel.Topic,
                Description = inputModel.Description,
                StartDate = startDate,
                EndDate = endDate,
                Latitude = inputModel.Latitude,
                Longitude = inputModel.Longitude,
                Seats = inputModel.Seats,
                TicketPrice = inputModel.TicketPrice,
                Image = inputModel.Image,
                PublisherId = Guid.Parse(moderatorId)
            };

            await _eventRepository.AddAsync(newEvent);
            await _eventRepository.SaveChangesAsync();

            return newEvent.Id.ToString();
        }

        /// <summary>
        /// Retrieves an event for deletion confirmation.
        /// </summary>
        /// <param name="eventId">The ID of the event to retrieve.</param>
        /// <param name="moderatorId">The ID of the moderator requesting deletion.</param>
        /// <returns>A <see cref="EventDeleteViewModel"/> with event details if found; otherwise, <c>null</c>.</returns>
        public async Task<EventDeleteViewModel?> DeleteEventGetAsync(string eventId, string moderatorId)
        {
            IEnumerable<Event> events = await _eventRepository.GetWithIncludeAsync(e => e.Publisher.User);

            Event? e = events.FirstOrDefault(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == moderatorId && e.IsDeleted == false);

            EventDeleteViewModel model = new EventDeleteViewModel()
            {
                Id = e.Id.ToString(),
                Topic = e.Topic,
                PublisherName = e.Publisher.User.UserName,
                PublisherId = e.PublisherId.ToString(),
            };

            return model;
        }

         /// <summary>
        /// Marks an event as deleted in the repository.
        /// </summary>
        /// <param name="eventId">The ID of the event to delete.</param>
        /// <param name="moderatorId">The ID of the moderator performing the deletion.</param>
        public async Task DeleteEventPostAsync(string eventId, string moderatorId)
        {
            Event? e = await _eventRepository
                .FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == moderatorId && e.IsDeleted == false);

            e.IsDeleted = true;

            await _eventRepository.SaveChangesAsync();


        }

        /// <summary>
        /// Retrieves an event for editing.
        /// </summary>
        /// <param name="eventId">The ID of the event to retrieve for editing.</param>
        /// <param name="moderatorId">The ID of the moderator requesting to edit.</param>
        /// <returns>An <see cref="EventInputViewModel"/> with event details if found; otherwise, <c>null</c>.</returns>
        public async Task<EventInputViewModel?> EditEventGetAsync(string eventId, string moderatorId)
        {
            Event? e = await _eventRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == moderatorId && e.IsDeleted == false);

            EventInputViewModel model = new EventInputViewModel()
            {
                Topic = e.Topic,
                Description = e.Description,
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                Seats = e.Seats,
                TicketPrice = e.TicketPrice,
                Image = e.Image,
            };

            return model;
        }

        /// <summary>
        /// Updates an event in the repository.
        /// </summary>
        /// <param name="inputModel">The input model containing updated event details.</param>
        /// <param name="eventId">The ID of the event to update.</param>
        /// <param name="moderatorId">The ID of the moderator performing the update.</param>
        /// <param name="startDate">The new start date of the event.</param>
        /// <param name="endDate">The new end date of the event.</param>
        /// <returns>The ID of the updated event as a string.</returns>
        public async Task<string> EditEventPostAsync(EventInputViewModel inputModel, string eventId, string moderatorId, DateTime startDate, DateTime endDate)
        {
            Event? e = await _eventRepository.FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == moderatorId && e.IsDeleted == false);

            if(e != null)
            {
                e.Topic = inputModel.Topic;
                e.Description = inputModel.Description;
                e.StartDate = startDate;
                e.EndDate = endDate;
                e.Latitude = inputModel.Latitude;
                e.Longitude = inputModel.Longitude;
                e.Seats = inputModel.Seats;
                e.TicketPrice = inputModel.TicketPrice;
                e.Image = inputModel.Image;
                e.PublisherId = Guid.Parse(moderatorId);
            }

            await _eventRepository.SaveChangesAsync();

            return e.Id.ToString();
        }

        /// <summary>
        /// Checks if an event with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the event to check.</param>
        /// <returns><c>true</c> if the event exists and is not marked as deleted; otherwise, <c>false</c>.</returns>
        public async Task<bool> EventExistById(string id)
        {
            Event? result = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Id.ToString() == id && e.IsDeleted == false);


            if (result == null)
                return false;


            return true;
        }

        /// <summary>
        /// Checks if an event with the specified topic already exists.
        /// </summary>
        /// <param name="topic">The topic of the event to check.</param>
        /// <returns><c>true</c> if an event with the topic exists and is not marked as deleted; otherwise, <c>false</c>.</returns>
        public async Task<bool> EventExistByTitle(string topic)
        {
            Event? isExisting = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Topic == topic && e.IsDeleted == false);

            if (isExisting == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Retrieves all events that are not marked as deleted.
        /// </summary>
        /// <returns>A collection of <see cref="EventIndexViewModel"/> representing each event.</returns>
        public async Task<IEnumerable<EventIndexViewModel>> GetAllEventsAsync()
        {
            IEnumerable<Event> events = await _eventRepository.GetWithIncludeAsync(e => e.Publisher.User);

            IEnumerable<EventIndexViewModel> eventIndexViewModels = events
                .Where(e => e.IsDeleted == false)
                .Select(e => new EventIndexViewModel
                {
                    Id = e.Id.ToString(),
                    Topic = e.Topic,
                    StartDate = e.StartDate.ToString(EventConstants.EventDateTimeFormat),
                    EndDate = e.EndDate.ToString(EventConstants.EventDateTimeFormat),
                    Seats = e.Seats,
                    TicketPrice = e.TicketPrice.ToString("C"),
                    Image = e.Image,
                    PublisherName = e.Publisher.User.UserName
                });

            return eventIndexViewModels;
        }

        /// <summary>
        /// Retrieves detailed information for a specific event by its ID.
        /// </summary>
        /// <param name="id">The ID of the event to retrieve.</param>
        /// <returns>An <see cref="EventDetailsViewModel"/> with detailed event information.</returns>
        public async Task<EventDetailsViewModel> GetEventDetailsByIdAsync(string id)
        {
            IEnumerable<Event> events = await _eventRepository.GetWithIncludeAsync(e => e.Publisher.User);

            Event? e = events.FirstOrDefault(x => x.Id.ToString() == id);

            EventDetailsViewModel eventDetailsViewModel = new EventDetailsViewModel()
            {
                Id = e.Id.ToString(),
                Topic = e.Topic,
                Description = e.Description,
                StartDate = e.StartDate.ToString(EventConstants.EventDateTimeFormat),
                EndDate = e.EndDate.ToString(EventConstants.EventDateTimeFormat),
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                Seats = e.Seats,
                TicketPrice = e.TicketPrice.ToString("C"),
                Image = e.Image,
                PublisherName = e.Publisher.User.UserName
            };

            return eventDetailsViewModel;
        }

        /// <summary>
        /// Checks if a specific event has a publisher with the given moderator ID.
        /// </summary>
        /// <param name="moderatorId">The ID of the moderator.</param>
        /// <param name="eventId">The ID of the event to check.</param>
        /// <returns><c>true</c> if the event is associated with the specified moderator; otherwise, <c>false</c>.</returns>
        public async Task<bool> HasPublisherWithIdAsync(string moderatorId, string eventId)
        {
            Event? e = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == moderatorId);

            if (e == null)
            {
                return false;
            }

            return true;
        }
    }
}
