using System.ComponentModel.DataAnnotations;

namespace BankAssignment.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; } 

        [Required]
        public string Password { get; set; }
    }
}