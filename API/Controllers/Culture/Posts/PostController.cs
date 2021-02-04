using API.Interfaces.Culture.Posts;
using API.Models.Culture.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Culture.Posts
{

    [ApiController]
    [Authorize]
    [Route("culture/posts")]

    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("v1/all")]
        public IActionResult GetPosts()
        {
            var posts = _postRepository.GetPosts();

            if (posts == null) return NotFound("Ops! Não há publicações");
            else return Ok(posts);
        }

        [HttpGet("v1")]
        public IActionResult GetPostsById([FromBody] Guid id)
        {
            var post = _postRepository.GetPostById(id);

            if (post == null) return NotFound("Publicação não encontrada");
            else return Ok(post);
        }

        [HttpPost("v1/add")]
        public async Task<IActionResult> AddPosts([FromBody] Post post)
        {
            var _post = await _postRepository.AddPost(post);

            if (_post == null) return NotFound("Publicação não encontrada");
            else return Ok(_post);
        }

        [HttpPut("v1/edit")]
        public async Task<IActionResult> EditPosts([FromBody] Post post)
        {
            var _post = await _postRepository.EditPost(post);

            if (_post == null) return NotFound("Publicação não encontrada");
            else return Ok(_post);
        }

        [HttpDelete("v1/delete")]
        public async Task<IActionResult> DeletePosts([FromBody] Guid id)
        {
            var _post = await _postRepository.DeletePost(id);

            if (_post == false) return NotFound("Publicação não encontrada");
            else return Ok(_post);
        }

    }
}
