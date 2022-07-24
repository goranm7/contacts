using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Contacts_API.Models;

namespace Contacts_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactContext _context;

        public ContactController(ContactContext context)
        {
           _context = context;
       }



        // GET: api/ContactDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts(string? name, string? surname, int? tagId)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }

            var contacts = from c in _context.Contacts select c;

            if (!String.IsNullOrEmpty(name))
            {
                contacts = contacts.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }
            if (!String.IsNullOrEmpty(surname))
            {
                contacts = contacts.Where(c => c.Surname.ToLower().Contains(surname.ToLower()));
            }
            if (tagId != null)
            {
                contacts = contacts.Where(c => c.TagId == tagId);
            }

            return await contacts.AsNoTracking().ToListAsync();
        }

        // GET: api/ContactDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            var contactDetail = await _context.Contacts.FindAsync(id);

            if (contactDetail == null)
            {
                return NotFound();
            }

            contactDetail.Emails = await _context.Emails.Where(e => e.ContactId == contactDetail.Id).ToListAsync();
            contactDetail.Numbers = await _context.Telephones.Where(e => e.ContactId == contactDetail.Id).ToListAsync();
            if (contactDetail.TagId != 0)
                contactDetail.Tag = await _context.Tags.FindAsync(contactDetail.TagId);

            return contactDetail;
        }

        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contactDetail)
        {
            if (id != contactDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailExists(id))
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

        // POST: api/ContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contactDetail)
        {
          if (_context.Contacts == null)
          {
              return Problem("Entity set 'ContactDetailContext.ContactDetails'  is null.");
          }
            _context.Contacts.Add(contactDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactDetail", new { id = contactDetail.Id }, contactDetail);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var contactDetail = await _context.Contacts.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contactDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactDetailExists(int id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

       
    }
}
