using API.Interfaces.Culture.Events;
using API.Models.Culture.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Culture.Events
{

    [ApiController]
    [Authorize]
    [Route("culture/events")]

    public class EventsController : ControllerBase
    {

        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet("v1/all")]
        public IActionResult GetEvents()
        {
            var Eventss = _eventRepository.GetEvents();

            if (Eventss == null) return NotFound("Ops! Não há eventos");
            else return Ok(Eventss);
        }

        [HttpGet("v1")]
        public IActionResult GetEventsById([FromBody] Guid id)
        {
            var Eventss = _eventRepository.GetEventById(id);

            if (Eventss == null) return NotFound("Evento não encontrado");
            else return Ok(Eventss);
        }

        [HttpPost("v1/add")]
        public async Task<IActionResult> AddEvents([FromBody] Event evento)
        {
            var _event = await _eventRepository.AddEvent(evento);

            if (_event == null) return NotFound("Evento não encontrado");
            else return Ok(_event);
        }

        [HttpPut("v1/edit")]
        public async Task<IActionResult> EditEvents([FromBody] Event evento)
        {
            var _event = await _eventRepository.EditEvent(evento);

            if (_event == null) return NotFound("Evento não encontrado");
            else return Ok(_event);
        }

        [HttpDelete("v1/delete")]
        public async Task<IActionResult> DeleteEvents([FromBody] Guid id)
        {
            var _event = await _eventRepository.DeleteEvent(id);

            if (_event == false) return NotFound("Evento não encontrado");
            else return Ok(_event);
        }

    }
}
