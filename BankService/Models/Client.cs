using System.ComponentModel.DataAnnotations;

namespace BankService.Models;

public class Client
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    [Required]
    public int Passport { get; set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime BirthdayData { get; set; }
    
}