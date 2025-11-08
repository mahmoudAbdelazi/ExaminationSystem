using ExaminationSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ExaminationSystem.Models
{
    public class User : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;

        public Role Role { get; set; }
    }
}
