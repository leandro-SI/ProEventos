using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain.Models;
using ProEventos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        private readonly ProEventosContext _context = null;

        public EventoController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetEventos")]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet]
        [Route("GetEventoById")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
        }

    }
}
