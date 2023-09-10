using AutoMapper;
using Models.Response;
using Repo.Ef.Repository;
using Repo.Ef;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repo.Ef.Models;
using Microsoft.AspNetCore.Identity; // Aggiunto per Identity

namespace UniConnect.BLL.Service
{
    public class EventoService
    {
        private readonly IRepository<Evento> _repository;
        private readonly IRepositoryEventi _repositoryEventi;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager; // Aggiunto per Identity

        public EventoService(IRepository<Evento> repository, IRepositoryEventi repositoryEventi, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _repositoryEventi = repositoryEventi;
            _mapper = mapper;
            _userManager = userManager; // Inizializzato per Identity
        }

        public async Task<List<EventoResponse>> GetEventiAsync()
        {
            var eventi = await _repository.GetAllAsync();
            return _mapper.Map<List<EventoResponse>>(eventi);
        }

        public async Task<EventoResponse> GetEventoByIdAsync(int id)
        {
            var evento = await _repository.GetByIdAsync(id);
            return _mapper.Map<EventoResponse>(evento);
        }

        public async Task<bool> CreateEventoAsync(EventoRequest evento)
        {
            if (evento == null)
            {
                return false;
            }

            var eventoDb = _mapper.Map<Evento>(evento);

            eventoDb.UserId = evento.IdUser;
            var existingUser = await _userManager.FindByIdAsync(evento.IdUser);
            List<ApplicationUser> itemList = new List<ApplicationUser> { existingUser };

            eventoDb.User = itemList;

            await _repository.AddAsync(eventoDb);
            return true;
        }

        public async Task<bool> UpdateEventoAsync(int id, EventoRequest updatedEvento)
        {
            if (updatedEvento == null || id != updatedEvento.EventId)
            {
                return false;
            }

            var existingEvento = await _repository.GetByIdAsync(id);
            if (existingEvento == null)
            {
                return false;
            }

            _mapper.Map(updatedEvento, existingEvento);
            await _repository.UpdateAsync(existingEvento);
            return true;
        }

        public async Task<bool> DeleteEventoAsync(int id)
        {
            var evento = await _repository.GetByIdAsync(id);
            if (evento == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<EventiResponse> GetEventiAsync(string userId)
        {
            var eventiAssociati = await _repositoryEventi.GetEventiAssociatiAsync(userId);
            var eventiCreati = await _repositoryEventi.GetEventiCreatiAsync(userId);
            var altriEventi = await _repositoryEventi.GetAltriEventiAsync(userId);

            var response = new EventiResponse
            {
                EventiAssociati = _mapper.Map<List<EventoResponse>>(eventiAssociati),
                EventiCreati = _mapper.Map<List<EventoResponse>>(eventiCreati),
                AltriEventi = _mapper.Map<List<EventoResponse>>(altriEventi)
            };

            return response;
        }

        public async Task<List<EventoResponse>> GetEventiMasterDataAsync(string userId)
        {
            var eventiAssociati = await _repositoryEventi.GetEventiAssociatiAsync(userId);
            return _mapper.Map<List<EventoResponse>>(eventiAssociati);
        }
    }
}
