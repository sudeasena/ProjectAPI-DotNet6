using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.DatabaseContext;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("api/tags")]


    public class TagController : ControllerBase
    {
        private readonly DsnContext _context;

        public TagController(DsnContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tag>>> Get()
        {
            return Ok(await _context.Tags.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> Get(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null) return BadRequest("Tag not found");
            return Ok(tag);
        }

        [HttpPost]
        public async Task<ActionResult<List<Tag>>> AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return Ok(await _context.Tags.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Tag>>> UpdateTag(Tag request)
        {
            var dbTag = await _context.Tags.FindAsync(request.Id);
            if (dbTag == null)
                return BadRequest("Tag not found");

            dbTag.Name = request.Name;

            await _context.SaveChangesAsync();

            return Ok(await _context.Tags.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Tag>>> Delete(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
                return BadRequest("Tag not found");
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tags.ToListAsync());
        }
    }
}
