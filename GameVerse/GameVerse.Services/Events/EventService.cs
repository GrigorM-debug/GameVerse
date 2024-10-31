﻿using GameVerse.Data.Models.Events;
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

        public async Task<string> AddEventAsync(EventInputViewModel inputModel, string userId)
        {
            bool isEventAlreadyExist = await EventExistByTitle(inputModel.Topic);

            if(isEventAlreadyExist)
            {
                return null;
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
                PublisherId = Guid.Parse(userId)
            };

            await _eventRepository.AddAsync(newEvent);
            await _eventRepository.SaveChangesAsync();

            return newEvent.Id.ToString();
        }

        public async Task<EventDeleteViewModel?> DeleteEventGetAsync(Guid eventId, Guid useId)
        {
            IEnumerable<Event> events = await _eventRepository.GetWithIncludeAsync(e => e.Publisher);

            Event? e = events.FirstOrDefault(e => e.Id == eventId && e.PublisherId == useId);

            EventDeleteViewModel model = new EventDeleteViewModel()
            {
                Id = e.Id.ToString(),
                Topic = e.Topic,
                PublisherName = e.Publisher.UserName,
                PublisherId = e.PublisherId.ToString(),
            };

            return model;
        }

        public async Task<bool> DeleteEventPostAsync(Guid eventId, Guid userId)
        {
            Event? e = await _eventRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(e => e.Id == eventId && e.PublisherId == userId);

            if (e == null)
            {
                return false;
            }

            e.IsDeleted = true;
           
            await _eventRepository.SaveChangesAsync();
            return true;
        }

        public async Task<EventInputViewModel?> EditEventGetAsync(string eventId, string userId)
        {
            Event? e = await _eventRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == userId);

            EventInputViewModel model = new EventInputViewModel()
            {
                Topic = e.Topic,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                Seats = e.Seats,
                TicketPrice = e.TicketPrice,
                Image = e.Image,
            };

            return model;
        }

        public async Task EditEventPostAsync(EventInputViewModel inputModel, string eventId, string userId)
        {
            Event? e = await _eventRepository.FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == userId);

            e.Topic = inputModel.Topic;
            e.Description = inputModel.Description;
            e.StartDate = inputModel.StartDate;
            e.EndDate = inputModel.EndDate;
            e.Latitude = inputModel.Latitude;
            e.Longitude = inputModel.Longitude;
            e.Seats = inputModel.Seats;
            e.TicketPrice = inputModel.TicketPrice;
            e.Image = inputModel.Image;
            e.PublisherId = Guid.Parse(userId);

            await _eventRepository.SaveChangesAsync();
        }

        public async Task<bool> EventExistById(string id)
        {
            Event? result = await _eventRepository.GetByIdAsync(Guid.Parse(id));


            if(result == null) 
                return false;


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
