﻿using ProEventos.Application.Services.Interface;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist = null;
        private readonly IEventoPersist _eventoPersist = null;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update<Evento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id);
                }

                return null;

            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId);

                if (evento == null) throw new Exception("Evento não encontrado!");

                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangesAsync();

            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }


    }
}
