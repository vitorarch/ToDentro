using API.Models.Culture.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Culture.Events
{
    public interface IEventRepository
    {

        public IEnumerable<Event> GetEvents();
        public Task<Event> GetEventById(Guid id);
        public Task<Event> AddEvent(Event evento);
        public Task<Event> EditEvent(Event evento);
        public Task<bool> DeleteEvent(Guid id);

    }
}
