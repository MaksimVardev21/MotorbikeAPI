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
    public class RentalBookingsController : ControllerBase
    {
        private readonly MotorbikeContext _context;

        public RentalBookingsController(MotorbikeContext context)
        {
            _context = context;
        }

        // GET: api/RentalBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalBooking>>> GetRentalBooking()
        {
          if (_context.RentalBooking == null)
          {
              return NotFound();
          }
            return await _context.RentalBooking.ToListAsync();
        }

        // GET: api/RentalBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalBooking>> GetRentalBooking(int id)
        {
          if (_context.RentalBooking == null)
          {
              return NotFound();
          }
            var rentalBooking = await _context.RentalBooking.FindAsync(id);

            if (rentalBooking == null)
            {
                return NotFound();
            }

            return rentalBooking;
        }

        // PUT: api/RentalBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentalBooking(int id, RentalBooking rentalBooking)
        {
            if (id != rentalBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentalBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalBookingExists(id))
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

        // POST: api/RentalBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentalBooking>> PostRentalBooking(RentalBooking rentalBooking)
        {
          if (_context.RentalBooking == null)
          {
              return Problem("Entity set 'MotorbikeContext.RentalBooking'  is null.");
          }
            _context.RentalBooking.Add(rentalBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentalBooking", new { id = rentalBooking.Id }, rentalBooking);
        }

        // DELETE: api/RentalBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalBooking(int id)
        {
            if (_context.RentalBooking == null)
            {
                return NotFound();
            }
            var rentalBooking = await _context.RentalBooking.FindAsync(id);
            if (rentalBooking == null)
            {
                return NotFound();
            }

            _context.RentalBooking.Remove(rentalBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentalBookingExists(int id)
        {
            return (_context.RentalBooking?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
