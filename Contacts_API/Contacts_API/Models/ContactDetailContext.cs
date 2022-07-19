using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_API.Models
{
    public class ContactDetailContext:DbContext
    {
        public ContactDetailContext(DbContextOptions<ContactDetailContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
        }

        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<EmailDetail> EmailDetails { get; set; }
        public DbSet<TelephoneDetail> TelephoneDetails { get; set; }
        public DbSet<TagDetail> TagDetails { get; set; }

    }
}
