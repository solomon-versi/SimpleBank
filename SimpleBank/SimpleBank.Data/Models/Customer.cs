using System.ComponentModel.DataAnnotations;
using SimpleBank.Core.Models;

#nullable disable

namespace SimpleBank.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)] public string Name { get; set; }

        [Required]
        [MaxLength(11)]
        public string IdentityNumber { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public CustomerType Type { get; set; }
    }
}

#nullable enable