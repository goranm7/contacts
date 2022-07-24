using System.ComponentModel.DataAnnotations;

namespace Contacts_API.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

    }
}
