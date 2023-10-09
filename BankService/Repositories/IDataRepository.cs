using BankService.DTOs;
using BankService.Models;

namespace BankService;

public interface IDataRepository
{
    //GET
    Task<IEnumerable<Account>> GetAllAccounts();
    Task<IEnumerable<Card>> GetAllCards();
    Task<IEnumerable<Client>> GetAllClients();

    //POST
    Task<bool> PostAccount(string number, Account account);
    Task<bool> PostCard(string number, Card card);
    Task<bool> PostClient(int id, Client client);

    //PUT
    Task<bool> PutAccount(Account account);
    Task<bool> PutCard(Card card);
    Task<bool> PutClient(Client client);

    //DELETE
    Task<bool> DeleteAccount(string number);
    Task<bool> DeleteCard(string number);
    Task<bool> DeleteClient(int id);
    
    //FULL USER
    Task<IEnumerable<FullUserInfo>> GetFullUsers();
}