using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RCApi01.Models;

namespace RCApi01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Yonetici : ControllerBase
    {
        private readonly RCContext _context;

        public Yonetici(RCContext context)
        {
            _context = context;
        }

        // GET: api/Yonetici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YoneticiGiris>>> GetYoneticiGirises()
        {
          if (_context.YoneticiGirises == null)
          {
              return NotFound();
          }
            return await _context.YoneticiGirises.ToListAsync();
        }

        // GET: api/Yonetici/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YoneticiGiris>> GetYoneticiGiris(int id)
        {
          if (_context.YoneticiGirises == null)
          {
              return NotFound();
          }
            var yoneticiGiris = await _context.YoneticiGirises.FindAsync(id);

            if (yoneticiGiris == null)
            {
                return NotFound();
            }

            return yoneticiGiris;
        }

        // PUT: api/Yonetici/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYoneticiGiris(int id, YoneticiGiris yoneticiGiris)
        {
            if (id != yoneticiGiris.IdYGiris)
            {
                return BadRequest();
            }

            _context.Entry(yoneticiGiris).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YoneticiGirisExists(id))
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

        // POST: api/Yonetici
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<YoneticiGiris>> PostYoneticiGiris(YoneticiGiris yoneticiGiris)
        {
          if (_context.YoneticiGirises == null)
          {
              return Problem("Entity set 'RCContext.YoneticiGirises'  is null.");
          }
            _context.YoneticiGirises.Add(yoneticiGiris);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYoneticiGiris", new { id = yoneticiGiris.IdYGiris }, yoneticiGiris);
        }

        // DELETE: api/Yonetici/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYoneticiGiris(int id)
        {
            if (_context.YoneticiGirises == null)
            {
                return NotFound();
            }
            var yoneticiGiris = await _context.YoneticiGirises.FindAsync(id);
            if (yoneticiGiris == null)
            {
                return NotFound();
            }

            _context.YoneticiGirises.Remove(yoneticiGiris);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YoneticiGirisExists(int id)
        {
            return (_context.YoneticiGirises?.Any(e => e.IdYGiris == id)).GetValueOrDefault();
        }
    }
}
