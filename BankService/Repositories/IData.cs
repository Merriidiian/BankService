using BankService.Models;

namespace BankService;

public interface IData
{
    List<Account> Accounts();
    List<Card> Cards();
    List<Client> Clients();
    List<FullUserInfo> FullUserInfos();
}