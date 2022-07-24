using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts_API.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; } = string.Empty;
        [Column("Surname")]
        public string Surname { get; set; } = string.Empty;
        [Column("Nickname")]
        public string Nickname { get; set; } = string.Empty;
        [Column("Address")]
        public string Address { get; set; } = string.Empty;
        [Column("Tag")]
        public int? TagId { get; set; }
        public virtual Tag? Tag { get; set; }

        public virtual List<Email>? Emails { get; set; }

        public virtual List<Telephone>? Numbers { get; set; }
    }
}
