using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces.Events;
using GameVerse.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Services.Events
{
    public class EventService : BaseService, IEventService
    {
        private readonly IGenericRepository<Event, Guid> _eventRepository;

        public EventService(IGenericRepository<Event, Guid> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> AddEventAsync(EventInputViewModel inputModel, Guid userId)
        {
            bool isEventAlreadyExist = await EventExistByTitle(inputModel.Topic);

            if(isEventAlreadyExist)
            {
                return false;
            }

            Event newEvent = new Event()
            {
                Topic = inputModel.Topic,
                Description = inputModel.Description,
                StartDate = inputModel.StartDate,
                EndDate = inputModel.EndDate,
                Latitude = inputModel.Latitude,
                Longitude = inputModel.Longitude,
                Seats = inputModel.Seats,
                TicketPrice = inputModel.TicketPrice,
                Image = inputModel.Image,
                PublisherId = userId
            };

            await _eventRepository.AddAsync(newEvent);

            return true;
        }


        public async Task<bool> EventExistByTitle(string topic)
        {
            Event? isExisting = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Topic == topic);

            if (isExisting == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<EventIndexViewModel>> GetAllEventsAsync()
        {
            IEnumerable<Event> events = await _eventRepository.GetAllAsyncAsReadOnly();

            IEnumerable<EventIndexViewModel> eventIndexViewModels = events
                .Select(e => new EventIndexViewModel
            {
                    Id = e.Id.ToString(),
                    Topic = e.Topic,
                    StartDate = e.StartDate.ToString(EventConstants.EventDateTimeFormat),
                    EndDate = e.EndDate.ToString(EventConstants.EventDateTimeFormat),
                    Seats = e.Seats,
                    TicketPrice = e.TicketPrice.ToString("C"),
                    Image = e.Image,
            });

            return eventIndexViewModels;
        }

        public async Task<EventDetailsViewModel> GetEventDetailsByIdAsync(Guid id)
        {
            Event? e = await _eventRepository.GetByIdAsync(id);

            EventDetailsViewModel eventDetailsViewModel = new EventDetailsViewModel()
            {
                Id = e.Id.ToString(),
                Topic = e.Topic,
                Description = e.Description,
                StartDate = e.StartDate.ToString(EventConstants.EventDateTimeFormat),
                EndDate = e.EndDate.ToString( EventConstants.EventDateTimeFormat),
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                Seats = e.Seats,
                TicketPrice = e.TicketPrice.ToString("C"),
                Image = e.Image,
            };

            return eventDetailsViewModel;
        }
    }
}
