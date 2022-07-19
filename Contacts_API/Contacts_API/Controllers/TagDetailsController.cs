﻿using System;
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
    public class TagDetailsController : ControllerBase
    {
        private readonly ContactDetailContext _context;

        public TagDetailsController(ContactDetailContext context)
        {
            _context = context;
        }

        // GET: api/TagDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDetail>>> GetTagDetails()
        {
          if (_context.TagDetails == null)
          {
              return NotFound();
          }
            return await _context.TagDetails.ToListAsync();
        }

        // GET: api/TagDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagDetail>> GetTagDetail(int id)
        {
          if (_context.TagDetails == null)
          {
              return NotFound();
          }
            var tagDetail = await _context.TagDetails.FindAsync(id);

            if (tagDetail == null)
            {
                return NotFound();
            }

            return tagDetail;
        }

        // PUT: api/TagDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagDetail(int id, TagDetail tagDetail)
        {
            if (id != tagDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(tagDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagDetailExists(id))
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

        // POST: api/TagDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagDetail>> PostTagDetail(TagDetail tagDetail)
        {
          if (_context.TagDetails == null)
          {
              return Problem("Entity set 'ContactDetailContext.TagDetails'  is null.");
          }
            _context.TagDetails.Add(tagDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagDetail", new { id = tagDetail.Id }, tagDetail);
        }

        // DELETE: api/TagDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagDetail(int id)
        {
            if (_context.TagDetails == null)
            {
                return NotFound();
            }
            var tagDetail = await _context.TagDetails.FindAsync(id);
            if (tagDetail == null)
            {
                return NotFound();
            }

            _context.TagDetails.Remove(tagDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagDetailExists(int id)
        {
            return (_context.TagDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
