using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using Models.Response;
using Repo.Ef.Models;
using System;
using System.Threading.Tasks;
using UniConnect.BLL;
using UniConnect.BLL.Service;

namespace UniConnect.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sortedPosts = await _postService.GetSortedPostsAsync();
            return Ok(sortedPosts);
        }

        // GET api/Post/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // POST api/Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostRequestFile post)
        {
            if (post == null)
            {
                return BadRequest();
            }
            await _postService.AddPostAsync(post);
            return Ok();
        }

        // PUT api/Post/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Post updatedPost)
        {
            if (updatedPost == null || id != updatedPost.PostId)
            {
                return BadRequest();
            }

            var success = await _postService.UpdatePostAsync(id, updatedPost);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _postService.DeletePostAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
