using EntityFrameworkCore.EncryptColumn.Attribute;
using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    internal class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        [EncryptColumn]
        public string Password { get; set; } = null!;
        public int? GardenId { get; set; }
        public Garden? Garden { get; set; }
    }
}
