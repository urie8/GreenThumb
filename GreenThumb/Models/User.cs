using EntityFrameworkCore.EncryptColumn.Attribute;
using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        [EncryptColumn]
        public string Password { get; set; } = null!;
        public Garden? Garden { get; set; }
    }
}
