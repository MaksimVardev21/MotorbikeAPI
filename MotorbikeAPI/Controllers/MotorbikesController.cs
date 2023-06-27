using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorbikeAPI.Data;

namespace MotorbikeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikesController : ControllerBase
    {
        private readonly MotorbikeContext _context;

        public MotorbikesController(MotorbikeContext context)
        {
            _context = context;
        }

        // GET: api/Motorbikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motorbike>>> GetMotorbike()
        {
          if (_context.Motorbike == null)
          {
              return NotFound();
          }
            return await _context.Motorbike.ToListAsync();
        }

        // GET: api/Motorbikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motorbike>> GetMotorbike(int id)
        {
          if (_context.Motorbike == null)
          {
              return NotFound();
          }
            var motorbike = await _context.Motorbike.FindAsync(id);

            if (motorbike == null)
            {
                return NotFound();
            }

            return motorbike;
        }

        // PUT: api/Motorbikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorbike(int id, Motorbike motorbike)
        {
            if (id != motorbike.Id)
            {
                return BadRequest();
            }

            _context.Entry(motorbike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorbikeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Motorbikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Motorbike>> PostMotorbike(Motorbike motorbike)
        {
          if (_context.Motorbike == null)
          {
              return Problem("Entity set 'MotorbikeContext.Motorbike'  is null.");
          }
            _context.Motorbike.Add(motorbike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotorbike", new { id = motorbike.Id }, motorbike);
        }

        // DELETE: api/Motorbikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorbike(int id)
        {
            if (_context.Motorbike == null)
            {
                return NotFound();
            }
            var motorbike = await _context.Motorbike.FindAsync(id);
            if (motorbike == null)
            {
                return NotFound();
            }

            _context.Motorbike.Remove(motorbike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotorbikeExists(int id)
        {
            return (_context.Motorbike?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
