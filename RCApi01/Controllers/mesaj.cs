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
    public class mesaj : ControllerBase
    {
        private readonly RCContext _context;

        public mesaj(RCContext context)
        {
            _context = context;
        }

        // GET: api/mesaj
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesajlar>>> GetMesajlars()
        {
          if (_context.Mesajlars == null)
          {
              return NotFound();
          }
            return await _context.Mesajlars.ToListAsync();
        }

        // GET: api/mesaj/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mesajlar>> GetMesajlar(int id)
        {
          if (_context.Mesajlars == null)
          {
              return NotFound();
          }
            var mesajlar = await _context.Mesajlars.FindAsync(id);

            if (mesajlar == null)
            {
                return NotFound();
            }

            return mesajlar;
        }

        // PUT: api/mesaj/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesajlar(int id, Mesajlar mesajlar)
        {
            if (id != mesajlar.MesajNo)
            {
                return BadRequest();
            }

            _context.Entry(mesajlar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesajlarExists(id))
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

        // POST: api/mesaj
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mesajlar>> PostMesajlar(Mesajlar mesajlar)
        {
          if (_context.Mesajlars == null)
          {
              return Problem("Entity set 'RCContext.Mesajlars'  is null.");
          }
            _context.Mesajlars.Add(mesajlar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesajlar", new { id = mesajlar.MesajNo }, mesajlar);
        }

        // DELETE: api/mesaj/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesajlar(int id)
        {
            if (_context.Mesajlars == null)
            {
                return NotFound();
            }
            var mesajlar = await _context.Mesajlars.FindAsync(id);
            if (mesajlar == null)
            {
                return NotFound();
            }

            _context.Mesajlars.Remove(mesajlar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesajlarExists(int id)
        {
            return (_context.Mesajlars?.Any(e => e.MesajNo == id)).GetValueOrDefault();
        }
    }
}
