using System.ComponentModel.DataAnnotations;

namespace Contacts_API.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Mail { get; set; } = string.Empty;

        public int ContactId { get; set; }
        
    }
}
