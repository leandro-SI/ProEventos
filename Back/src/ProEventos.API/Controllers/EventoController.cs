using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;
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
        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() {
                EventoId = 1,
                Local = "São Paulo",
                DataEvento = "11/02/1991",
                Tema = "Azul",
                QtdPessoas = 250,
                Lote = "4754b",
                ImagemURL = "N/A"
            },
            new Evento() {
                EventoId = 2,
                Local = "Espirito Santo",
                DataEvento = "10/10/1996",
                Tema = "Vermelho",
                QtdPessoas = 120,
                Lote = "2222b",
                ImagemURL = "N/A"
            },

        };

        private readonly DataContext _context = null;

        public EventoController(DataContext context)
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
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

    }
}
