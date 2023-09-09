using AutoMapper;
using Models;
using Models.Response;
using Repo.Ef;
using Repo.Ef.Models;
using Repo.Ef.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniConnect.BLL.Service
{
    public class PostService
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;
        private readonly IRepositoryPost _repositoryPost;

        public PostService(IRepository<Post> repository, IMapper mapper, IRepositoryPost repositoryPost)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryPost = repositoryPost;
    }

        public async Task<List<PostResponse>> GetSortedPostsAsync()
        {
            var posts = await _repositoryPost.Get(); // Recupera tutti i post dal repository in modo asincrono
            var postResponses = _mapper.Map<List<PostResponse>>(posts);
            var sortedPosts = postResponses.OrderByDescending(p => p.Timestamp).ToList();
            return sortedPosts;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id); // Recupera il post per l'ID specificato dal repository in modo asincrono
        }

        public async Task AddPostAsync(PostRequest post)
        {
            var postDb = _mapper.Map<Post>(post);
            await _repository.AddAsync(postDb); // Inserisci il nuovo post nel repository in modo asincrono
        }

        public async Task<bool> UpdatePostAsync(int id, Post updatedPost)
        {
            var existingPost = await _repository.GetByIdAsync(id);
            if (existingPost == null)
            {
                return false; // Il post non esiste
            }

            existingPost.Content = updatedPost.Content;
            existingPost.Timestamp = updatedPost.Timestamp;

            await _repository.UpdateAsync(existingPost); // Aggiorna il post esistente nel repository in modo asincrono
            return true;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
            {
                return false; // Il post non esiste
            }

            await _repository.DeleteAsync(id); // Elimina il post dal repository in modo asincrono
            return true;
        }
    }
}
