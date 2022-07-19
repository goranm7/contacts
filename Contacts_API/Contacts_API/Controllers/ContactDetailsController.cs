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
    public class ContactDetailsController : ControllerBase
    {
        private readonly ContactDetailContext _context;

        public ContactDetailsController(ContactDetailContext context)
        {
            _context = context;
        }

        // GET: api/ContactDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDetail>>> GetContactDetails(string? name, string? surname, int? tagId)
        {
            if (_context.ContactDetails == null)
            {
              return NotFound();
            }

            var contactDetails = await _context.ContactDetails.ToListAsync();
            contactDetails = (name != null) ? contactDetails.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList() : contactDetails;
            contactDetails = (surname != null) ? contactDetails.Where(c => c.Surname.ToLower().Contains(surname.ToLower())).ToList() : contactDetails;
            contactDetails = (tagId != null) ? contactDetails.Where(c => c.TagDetailId == tagId).ToList() : contactDetails;

            foreach (ContactDetail contact in contactDetails)
            {
                contact.Emails = await _context.EmailDetails.Where(e => e.ContactDetailId == contact.Id).ToListAsync();
                contact.Numbers = await _context.TelephoneDetails.Where(e => e.ContactDetailId == contact.Id).ToListAsync();
                if (contact.TagDetailId != 0)
                    contact.TagDetail = await _context.TagDetails.FindAsync(contact.TagDetailId);
            }

            return contactDetails.ToList();
        }

        // GET: api/ContactDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDetail>> GetContactDetail(int id)
        {
          if (_context.ContactDetails == null)
          {
              return NotFound();
          }
            var contactDetail = await _context.ContactDetails.FindAsync(id);

            if (contactDetail == null)
            {
                return NotFound();
            }

            contactDetail.Emails = await _context.EmailDetails.Where(e => e.ContactDetailId == contactDetail.Id).ToListAsync();
            contactDetail.Numbers = await _context.TelephoneDetails.Where(e => e.ContactDetailId == contactDetail.Id).ToListAsync();
            if (contactDetail.TagDetailId != 0)
                contactDetail.TagDetail = await _context.TagDetails.FindAsync(contactDetail.TagDetailId);

            return contactDetail;
        }

        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactDetail(int id, ContactDetail contactDetail)
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
        public async Task<ActionResult<ContactDetail>> PostContactDetail(ContactDetail contactDetail)
        {
          if (_context.ContactDetails == null)
          {
              return Problem("Entity set 'ContactDetailContext.ContactDetails'  is null.");
          }
            _context.ContactDetails.Add(contactDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactDetail", new { id = contactDetail.Id }, contactDetail);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactDetail(int id)
        {
            if (_context.ContactDetails == null)
            {
                return NotFound();
            }
            var contactDetail = await _context.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            _context.ContactDetails.Remove(contactDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactDetailExists(int id)
        {
            return (_context.ContactDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        [Route("GetContactDetailsFilter")]
        public async Task<ActionResult> GetContactDetail(string? name,string? surname ,int? tagId)
        {
            if (_context.ContactDetails == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails.ToListAsync();
            contactDetails = (name != null) ? contactDetails.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList(): contactDetails;
            contactDetails = (surname != null) ? contactDetails.Where(c => c.Surname.ToLower().Contains(surname.ToLower())).ToList() : contactDetails;
            contactDetails = (tagId != null) ? contactDetails.Where(c => c.TagDetailId == tagId).ToList() : contactDetails;

            foreach (ContactDetail contact in contactDetails)
            {
                contact.Emails = await _context.EmailDetails.Where(e => e.ContactDetailId == contact.Id).ToListAsync();
                contact.Numbers = await _context.TelephoneDetails.Where(e => e.ContactDetailId == contact.Id).ToListAsync();
                if (contact.TagDetailId != 0)
                    contact.TagDetail = await _context.TagDetails.FindAsync(contact.TagDetailId);
            }
     

            return Ok(contactDetails);
        }
    }
}
