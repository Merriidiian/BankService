namespace BankService.Models;

public class FullUserInfo
{
    public Client Client { get; set; }
    public Account Accounts { get; set; }
    public Card Cards { get; set; }
}