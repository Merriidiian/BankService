using System.ComponentModel.DataAnnotations;

namespace BankService.Models;

public class Card
{
    [Key]
    [Required]
    public string Number { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    [Required]
    public int Svv { get; set; }
    
}