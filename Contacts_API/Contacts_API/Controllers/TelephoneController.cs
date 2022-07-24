using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contacts_API.Models;

namespace Contacts_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneController : ControllerBase
    {
        private readonly ContactContext _context;

        public TelephoneController(ContactContext context)
        {
            _context = context;
        }

        // GET: api/TelephoneDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telephone>>> GetTelephoneDetails()
        {
          if (_context.Telephones == null)
          {
              return NotFound();
          }
            return await _context.Telephones.ToListAsync();
        }

        // GET: api/TelephoneDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telephone>> GetTelephoneDetail(int id)
        {
          if (_context.Telephones == null)
          {
              return NotFound();
          }
            var telephoneDetail = await _context.Telephones.FindAsync(id);

            if (telephoneDetail == null)
            {
                return NotFound();
            }

            return telephoneDetail;
        }

        // PUT: api/TelephoneDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelephoneDetail(int id, Telephone telephoneDetail)
        {
            if (id != telephoneDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(telephoneDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelephoneDetailExists(id))
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

        // POST: api/TelephoneDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telephone>> PostTelephoneDetail(Telephone telephoneDetail)
        {
          if (_context.Telephones == null)
          {
              return Problem("Entity set 'ContactDetailContext.TelephoneDetails'  is null.");
          }
            _context.Telephones.Add(telephoneDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelephoneDetail", new { id = telephoneDetail.Id }, telephoneDetail);
        }

        // DELETE: api/TelephoneDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelephoneDetail(int id)
        {
            if (_context.Telephones == null)
            {
                return NotFound();
            }
            var telephoneDetail = await _context.Telephones.FindAsync(id);
            if (telephoneDetail == null)
            {
                return NotFound();
            }

            _context.Telephones.Remove(telephoneDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelephoneDetailExists(int id)
        {
            return (_context.Telephones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
