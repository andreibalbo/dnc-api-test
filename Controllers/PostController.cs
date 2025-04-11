using DncApiTest.Models;
using DncApiTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DncApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostRepository _repository;

        public PostController(PostRepository repository)
        {
            _repository = repository;
        }

        // GET: api/post
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        // GET: api/post/5
        [HttpGet("{id}")]
        public ActionResult<Post> GetById(int id)
        {
            var post = _repository.GetById(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        // POST: api/post
        [HttpPost]
        public ActionResult<Post> Create(Post post)
        {
            var createdPost = _repository.Create(post);
            return CreatedAtAction(nameof(GetById), new { id = createdPost.Id }, createdPost);
        }

        // PUT: api/post/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Post post)
        {
            var updatedPost = _repository.Update(id, post);
            if (updatedPost == null) return NotFound();
            return NoContent();
        }

        // DELETE: api/post/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repository.Delete(id)) return NotFound();
            return NoContent();
        }
    }
} 