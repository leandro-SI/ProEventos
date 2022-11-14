﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Services.Interface;
using ProEventos.Domain.Models;
using ProEventos.Persistence;
using ProEventos.Persistence.Context;
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

        private readonly IEventoService _eventoService = null;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        [Route("GetAllEventos")]
        public async Task<IActionResult> GetAllEventos()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);

                if (eventos == null) return NotFound("Nenhum evento encontrado.");

                return Ok(eventos);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os eventos. Erro: {_error.Message}");
            }
        }

        [HttpGet("{id}/id")]
        [Route("GetEventoById")]
        public async Task<IActionResult> GetEventoById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);

                if (evento == null) return NotFound("Nenhum evento encontrado.");

                return Ok(evento);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar o evento. Erro: {_error.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        [Route("GetEventosByTema")]
        public async Task<IActionResult> GetEventosByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);

                if (evento == null) return NotFound("Nenhum evento encontrado.");

                return Ok(evento);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os eventos. Erro: {_error.Message}");
            }
        }

        [HttpPost]
        [Route("SaveEvento")]
        public async Task<IActionResult> SaveEvento(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);

                if (evento == null) return BadRequest("Erro ao inserir evento.");

                return Ok(evento);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar o evento. Erro: {_error.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateEvento")]
        public async Task<IActionResult> UpdateEvento(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);

                if (evento == null) return BadRequest("Erro ao alterar evento.");

                return Ok(evento);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar alterar o evento. Erro: {_error.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Route("DeleteEvento")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            try
            {   
                return await _eventoService.DeleteEvento(id) ?
                        Ok("Deletado.") :
                        BadRequest("Erro ao deletar evento.");

            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar o Evento. Erro: {_error.Message}");
            }
        }

    }
}
