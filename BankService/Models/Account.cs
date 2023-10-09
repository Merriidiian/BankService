using System.ComponentModel.DataAnnotations;

namespace BankService.Models;

public class Account
{
    [Key]
    [Required]
    public string Number { get; set; }
    [Required]
    public int IdClient { get; set; }
    [Required]
    public long Inn { get; set; }
}