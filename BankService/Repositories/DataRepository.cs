using BankService.Models;

namespace BankService;

public class DataRepository : IDataRepository
{
    private readonly IData _data;

    public DataRepository(IData data)
    {
        _data = data;
    }
    

    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        return _data.Accounts().AsEnumerable();
    }

    public async Task<Account> GetAccount(string number)
    {
        return _data.Accounts().FirstOrDefault(n => n.Number == number);
    }

    public async Task<IEnumerable<Card>> GetAllCards()
    {
        return _data.Cards().AsEnumerable();
    }

    public async Task<Card> GetCard(string number)
    {
        return _data.Cards().FirstOrDefault(n => n.Number == number);
    }

    public async Task<IEnumerable<Client>> GetAllClients()
    {
        return _data.Clients().AsEnumerable();
    }
    

    public async Task<Client> GetClient(int id)
    {
        return _data.Clients().FirstOrDefault(n => n.Id == id);
    }

    public async Task<IEnumerable<FullUserInfo>> GetAllUsersInfo()
    {
        return _data.FullUserInfos().AsEnumerable();
    }

    public async Task<FullUserInfo> GetUserInfo(int id)
    {
        return _data.FullUserInfos().FirstOrDefault(n => n.Client.Id == id);
    }
    
}