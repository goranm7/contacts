using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts_API.Models
{
    public class ContactDetail
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
        public int? TagDetailId { get; set; }
        public virtual TagDetail? TagDetail { get; set; }

        public virtual List<EmailDetail>? Emails { get; set; }

        public virtual List<TelephoneDetail>? Numbers { get; set; }
    }
}
