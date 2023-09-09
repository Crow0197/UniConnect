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
    public class GruppoService
    {

        private readonly IRepository<Gruppo> _repository;
        private readonly IRepositoryGruppi _repositoryGruppi;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager; // Aggiunto per Identity



        public GruppoService(IRepository<Gruppo> repository, IRepositoryGruppi repositoryGruppi, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _repositoryGruppi = repositoryGruppi;
            _mapper = mapper;
            _userManager = userManager; // Inizializzato per Identity

        }

        public async Task<List<GruppoResponse>> GetGruppiAsync()
        {
            var gruppi = await _repository.GetAllAsync();
            return _mapper.Map<List<GruppoResponse>>(gruppi);
        }

        public async Task<GruppoResponse> GetGruppoByIdAsync(int id)
        {
            var gruppo = await _repository.GetByIdAsync(id);
            return _mapper.Map<GruppoResponse>(gruppo);
        }

        public async Task<bool> CreateGruppoAsync(GruppoRequest gruppo)
        {
            if (gruppo == null)
            {
                return false;
            }

            var gruppoDb = _mapper.Map<Gruppo>(gruppo);

            gruppoDb.UserId = gruppo.IdUser;
            var existingUser = await _userManager.FindByIdAsync(gruppo.IdUser);
            List<ApplicationUser> itemList = new List<ApplicationUser> { existingUser };

            gruppoDb.User = itemList;


            await _repository.AddAsync(gruppoDb);
            return true;
        }

        public async Task<bool> UpdateGruppoAsync(int id, GruppoRequest updatedGruppo)
        {
            if (updatedGruppo == null || id != updatedGruppo.GroupId)
            {
                return false;
            }

            var existingGruppo = await _repository.GetByIdAsync(id);
            if (existingGruppo == null)
            {
                return false;
            }

            _mapper.Map(updatedGruppo, existingGruppo);
            await _repository.UpdateAsync(existingGruppo);
            return true;
        }

        public async Task<bool> DeleteGruppoAsync(int id)
        {
            var gruppo = await _repository.GetByIdAsync(id);
            if (gruppo == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<GruppiResponse> GetGruppiAsync(string userId)
        {
            var gruppiAssociati = await _repositoryGruppi.GetGruppiAssociatiAsync(userId);
            var gruppiCreati = await _repositoryGruppi.GetGruppiCreatiAsync(userId);
            var altriGruppi = await _repositoryGruppi.GetAltriGruppiAsync(userId);

            var response = new GruppiResponse
            {
                GruppiAssociati = _mapper.Map<List<GruppoResponse>>(gruppiAssociati),
                GruppiCreati = _mapper.Map<List<GruppoResponse>>(gruppiCreati),
                AltriGruppi = _mapper.Map<List<GruppoResponse>>(altriGruppi)
            };

            return response;
        }

        public async Task<List<GruppoResponse>> GetGruppiMasterDataAsync(string userId)
        {
            var gruppiAssociati = await _repositoryGruppi.GetGruppiAssociatiAsync(userId);
            return _mapper.Map<List<GruppoResponse>>(gruppiAssociati);
        }
    }
}
