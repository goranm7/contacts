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
    public class EmailDetailsController : ControllerBase
    {
        private readonly ContactDetailContext _context;

        public EmailDetailsController(ContactDetailContext context)
        {
            _context = context;
        }

        // GET: api/EmailDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailDetail>>> GetEmailDetails()
        {
          if (_context.EmailDetails == null)
          {
              return NotFound();
          }
            return await _context.EmailDetails.ToListAsync();
        }

        // GET: api/EmailDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailDetail>> GetEmailDetail(int id)
        {
          if (_context.EmailDetails == null)
          {
              return NotFound();
          }
            var emailDetail = await _context.EmailDetails.FindAsync(id);

            if (emailDetail == null)
            {
                return NotFound();
            }

            return emailDetail;
        }

        // PUT: api/EmailDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailDetail(int id, EmailDetail emailDetail)
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
        public async Task<ActionResult<EmailDetail>> PostEmailDetail(EmailDetail emailDetail)
        {
          if (_context.EmailDetails == null)
          {
              return Problem("Entity set 'ContactDetailContext.EmailDetails'  is null.");
          }
            _context.EmailDetails.Add(emailDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailDetail", new { id = emailDetail.Id }, emailDetail);
        }

        // DELETE: api/EmailDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailDetail(int id)
        {
            if (_context.EmailDetails == null)
            {
                return NotFound();
            }
            var emailDetail = await _context.EmailDetails.FindAsync(id);
            if (emailDetail == null)
            {
                return NotFound();
            }

            _context.EmailDetails.Remove(emailDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailDetailExists(int id)
        {
            return (_context.EmailDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
