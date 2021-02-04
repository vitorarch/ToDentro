using API.DataAccess;
using API.Interfaces.Culture.Events;
using API.Models.Culture.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Culture.Events
{
    public class EventRepository : IEventRepository
    {

        private readonly ToDentroContext _context;

        public EventRepository(ToDentroContext context)
        {
            _context = context;
        }

        public IEnumerable<Event> GetEvents()
        {
            // fluent validation
            var eventList = _context.Events.ToList();
            return eventList;
        }

        public async Task<Event> GetEventById(Guid id)
        {
            // fluent validation
            if (id == null) return null;
            else
            {
                var evento = await _context.Events.FindAsync(id);
                return evento;
            }
        }

        public async Task<Event> AddEvent(Event evento)
        {
            // fluent validation
            if (evento == null) return null;
            else
            {
                evento.Id = Guid.NewGuid();

                await _context.Events.AddAsync(evento);
                await _context.SaveChangesAsync();
                return evento;
            }
        }

        public async Task<Event> EditEvent(Event evento)
        {
            // fluent validation
            if (evento == null) return null;
                    else
            {
                var _event = await _context.Events.FindAsync(evento.Id);
                _event = evento;

                _context.Entry(_event).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return evento;
            }
        }

        public async Task<bool> DeleteEvent(Guid id)
        {
            // fluent validation
            if (id == null) return false;
            else
            {
                var evento = await _context.Events.FindAsync(id);
                _context.Events.Remove(evento);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}
