using Microsoft.Extensions.Logging;
using ProEventos.Application.IService;
using ProEventos.Domain.Models;
using ProEventos.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Service
{
    public class EventoService : IEventoService
    {
        private readonly IBasePersist _basePersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IBasePersist basePersist, IEventoPersist eventoPersist)
        {
            _basePersist = basePersist;
            _eventoPersist = eventoPersist;
        }

        public IEventoPersist EventoPersist { get; }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _basePersist.Add<Evento>(model);

                if (await _basePersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _basePersist.Update<Evento>(model);

                if (await _basePersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventosByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                _basePersist.Delete<Evento>(evento);
                return await _basePersist.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(false);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, false);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
