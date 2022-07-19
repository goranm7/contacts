using System.ComponentModel.DataAnnotations;

namespace Contacts_API.Models
{
    public class EmailDetail
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public int ContactDetailId { get; set; }
        
    }
}
