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
    public class TelephoneDetailsController : ControllerBase
    {
        private readonly ContactDetailContext _context;

        public TelephoneDetailsController(ContactDetailContext context)
        {
            _context = context;
        }

        // GET: api/TelephoneDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelephoneDetail>>> GetTelephoneDetails()
        {
          if (_context.TelephoneDetails == null)
          {
              return NotFound();
          }
            return await _context.TelephoneDetails.ToListAsync();
        }

        // GET: api/TelephoneDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TelephoneDetail>> GetTelephoneDetail(int id)
        {
          if (_context.TelephoneDetails == null)
          {
              return NotFound();
          }
            var telephoneDetail = await _context.TelephoneDetails.FindAsync(id);

            if (telephoneDetail == null)
            {
                return NotFound();
            }

            return telephoneDetail;
        }

        // PUT: api/TelephoneDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelephoneDetail(int id, TelephoneDetail telephoneDetail)
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
        public async Task<ActionResult<TelephoneDetail>> PostTelephoneDetail(TelephoneDetail telephoneDetail)
        {
          if (_context.TelephoneDetails == null)
          {
              return Problem("Entity set 'ContactDetailContext.TelephoneDetails'  is null.");
          }
            _context.TelephoneDetails.Add(telephoneDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelephoneDetail", new { id = telephoneDetail.Id }, telephoneDetail);
        }

        // DELETE: api/TelephoneDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelephoneDetail(int id)
        {
            if (_context.TelephoneDetails == null)
            {
                return NotFound();
            }
            var telephoneDetail = await _context.TelephoneDetails.FindAsync(id);
            if (telephoneDetail == null)
            {
                return NotFound();
            }

            _context.TelephoneDetails.Remove(telephoneDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelephoneDetailExists(int id)
        {
            return (_context.TelephoneDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
