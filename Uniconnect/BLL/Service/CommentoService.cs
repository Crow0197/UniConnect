using AutoMapper;
using Models.Response;
using Models;
using Repo.Ef;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repo.Ef.Models;
using Repo.Ef.Repository;

namespace UniConnect.BLL.Service
{
    public class CommentoService
    {
        private readonly IRepository<Commento> _repository;
        private readonly IMapper _mapper;
        private readonly IRepositoryCommento _repositoryCommento;


        public CommentoService(IRepository<Commento> repository, IMapper mapper, IRepositoryCommento repositoryCommento)
        {
            _repository = repository;
            _mapper = mapper;
            _repository = repository;
            _repositoryCommento = repositoryCommento;
        }

        public async Task<List<CommentiResponse>> GetCommentiAsync(int postId)
        {
            var commenti = await _repositoryCommento.Get(postId);
            return _mapper.Map<List<CommentiResponse>>(commenti);
        }

        public async Task<bool> CreateCommentoAsync(CommentoRequest commento)
        {
            if (commento == null)
            {
                return false;
            }

            var commentoDb = _mapper.Map<Commento>(commento);
            await _repository.AddAsync(commentoDb);
            return true;
        }

        public async Task<bool> UpdateCommentoAsync(int id, CommentoRequest updatedCommento)
        {
            if (updatedCommento == null || id != updatedCommento.CommentId)
            {
                return false;
            }

            var existingCommento = await _repository.GetByIdAsync(id);

            if (existingCommento == null)
            {
                return false;
            }

            _mapper.Map(updatedCommento, existingCommento);
            await _repository.UpdateAsync(existingCommento);
            return true;
        }

        public async Task<bool> DeleteCommentoAsync(int id)
        {
            var commento = await _repository.GetByIdAsync(id);

            if (commento == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
