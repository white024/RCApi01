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
    public class kullanici : ControllerBase
    {
        private readonly RCContext _context;

        public kullanici(RCContext context)
        {
            _context = context;
        }

        // GET: api/kullanici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KullaniciList>>> GetKullaniciLists()
        {
          if (_context.KullaniciLists == null)
          {
              return NotFound();
          }
            return await _context.KullaniciLists.ToListAsync();
        }

        // GET: api/kullanici/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KullaniciList>> GetKullaniciList(int id)
        {
          if (_context.KullaniciLists == null)
          {
              return NotFound();
          }
            var kullaniciList = await _context.KullaniciLists.FindAsync(id);

            if (kullaniciList == null)
            {
                return NotFound();
            }

            return kullaniciList;
        }

        // PUT: api/kullanici/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKullaniciList(int id, KullaniciList kullaniciList)
        {
            if (id != kullaniciList.IdKullanici)
            {
                return BadRequest();
            }

            _context.Entry(kullaniciList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullaniciListExists(id))
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

        // POST: api/kullanici
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KullaniciList>> PostKullaniciList(KullaniciList kullaniciList)
        {
          if (_context.KullaniciLists == null)
          {
              return Problem("Entity set 'RCContext.KullaniciLists'  is null.");
          }
            _context.KullaniciLists.Add(kullaniciList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKullaniciList", new { id = kullaniciList.IdKullanici }, kullaniciList);
        }

        // DELETE: api/kullanici/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKullaniciList(int id)
        {
            if (_context.KullaniciLists == null)
            {
                return NotFound();
            }
            var kullaniciList = await _context.KullaniciLists.FindAsync(id);
            if (kullaniciList == null)
            {
                return NotFound();
            }

            _context.KullaniciLists.Remove(kullaniciList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KullaniciListExists(int id)
        {
            return (_context.KullaniciLists?.Any(e => e.IdKullanici == id)).GetValueOrDefault();
        }
    }
}
