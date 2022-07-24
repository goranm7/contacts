using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_API.Models
{
    public class ContactContext:DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
