using BankService.Models;

namespace BankService;

public interface IDataRepository
{
    //GET
    Task<IEnumerable<Account>> GetAllAccounts();
    Task<Account> GetAccount(string number);
    
    Task<IEnumerable<Card>> GetAllCards();
    Task<Card> GetCard(string number);
    
    Task<IEnumerable<Client>> GetAllClients();
    Task<Client> GetClient(int id);
    
    Task<IEnumerable<FullUserInfo>> GetAllUsersInfo();
    Task<FullUserInfo> GetUserInfo(int id);

    //POST
    
}