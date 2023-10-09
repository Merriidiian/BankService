using BankService.Models;

namespace BankService.DTOs;

public class FullUserInfo
{
    public Client Client { get; set; }
    public Account Account { get; set; }
    public List<Card> Cards { get; set; }
}