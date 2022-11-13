using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interface
{
    public interface IProEventosPersistence
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);

        //PALESTRANTES
        Task<Evento[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Evento[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Evento> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}
