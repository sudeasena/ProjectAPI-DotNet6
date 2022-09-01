using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.DatabaseContext;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly DsnContext _context;

        public PostController(DsnContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get()
        {
            return Ok(await _context.Posts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return BadRequest("Post not found");
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<List<Post>>> AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return Ok(await _context.Posts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Post>>> UpdatePost(Post request)
        {
            var dbPost = await _context.Posts.FindAsync(request.Id);
            if (dbPost == null)
                return BadRequest("Post not found");

            dbPost.Title = request.Title;

            await _context.SaveChangesAsync();

            return Ok(await _context.Posts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Post>>> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return BadRequest("Post not found");
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok(await _context.Posts.ToListAsync());
        }
    }
}
