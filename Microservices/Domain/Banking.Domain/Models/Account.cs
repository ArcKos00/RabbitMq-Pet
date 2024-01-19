using System.ComponentModel.DataAnnotations;

namespace Banking.Domain.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Money { get; set; }
    }
}
