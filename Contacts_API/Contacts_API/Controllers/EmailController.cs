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
    public class EmailController : ControllerBase
    {
        private readonly ContactContext _context;

        public EmailController(ContactContext context)
        {
            _context = context;
        }

        // GET: api/EmailDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmailDetails()
        {
          if (_context.Emails == null)
          {
              return NotFound();
          }
            return await _context.Emails.ToListAsync();
        }

        // GET: api/EmailDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmailDetail(int id)
        {
          if (_context.Emails == null)
          {
              return NotFound();
          }
            var emailDetail = await _context.Emails.FindAsync(id);

            if (emailDetail == null)
            {
                return NotFound();
            }

            return emailDetail;
        }

        // PUT: api/EmailDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailDetail(int id, Email emailDetail)
        {
            if (id != emailDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(emailDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailDetailExists(id))
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

        // POST: api/EmailDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmailDetail(Email emailDetail)
        {
          if (_context.Emails == null)
          {
              return Problem("Entity set 'ContactDetailContext.EmailDetails'  is null.");
          }
            _context.Emails.Add(emailDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailDetail", new { id = emailDetail.Id }, emailDetail);
        }

        // DELETE: api/EmailDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailDetail(int id)
        {
            if (_context.Emails == null)
            {
                return NotFound();
            }
            var emailDetail = await _context.Emails.FindAsync(id);
            if (emailDetail == null)
            {
                return NotFound();
            }

            _context.Emails.Remove(emailDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailDetailExists(int id)
        {
            return (_context.Emails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
