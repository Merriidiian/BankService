using BankService.DTOs;
using BankService.Models;

namespace BankService.Repositories;

public class DataRepository : IDataRepository
{
    private readonly DataContext _context;

    public DataRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        return _context.Accounts;
    }

    public async Task<IEnumerable<Card>> GetAllCards()
    {
        return _context.Cards;
    }

    public async Task<IEnumerable<Client>> GetAllClients()
    {
        return _context.Clients;
    }

    public async Task<bool> PostAccount(string number, Account account)
    {
        _context.Accounts.Update(account);
        /*_context.Accounts.FirstOrDefault(a => a.Number == number)!.Inn = account.Inn;
        _context.Accounts.FirstOrDefault(a => a.Number == number)!.IdClient = account.IdClient;*/
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> PostCard(string number, Card card)
    {
        _context.Cards.Update(card);
        /*_context.Cards.FirstOrDefault(a => a.Number == number)!.Svv = card.Svv;
        _context.Cards.FirstOrDefault(a => a.Number == number)!.EndTime = card.EndTime;
        _context.Cards.FirstOrDefault(a => a.Number == number)!.NumberAccount = card.NumberAccount;*/
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> PostClient(int id, Client client)
    {
        _context.Clients.Update(client);
        /*_context.Clients.FirstOrDefault(a => a.Id == id)!.Name = client.Name;
        _context.Clients.FirstOrDefault(a => a.Id == id)!.Passport = client.Passport;
        _context.Clients.FirstOrDefault(a => a.Id == id)!.Patronymic = client.Patronymic;
        _context.Clients.FirstOrDefault(a => a.Id == id)!.Surname = client.Surname;
        _context.Clients.FirstOrDefault(a => a.Id == id)!.BirthdayData = client.BirthdayData;*/
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> PutAccount(Account account)
    {
        _context.Accounts.Add(account);
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> PutCard(Card card)
    {
        _context.Cards.Add(card);
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> PutClient(Client client)
    {
        _context.Clients.Add(client);
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> DeleteAccount(string number)
    {
        _context.Accounts.Remove(_context.Accounts.FirstOrDefault(n => n.Number == number));
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> DeleteCard(string number)
    {
        _context.Cards.Remove(_context.Cards.FirstOrDefault(n => n.Number == number));
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> DeleteClient(int id)
    {
        _context.Clients.Remove(_context.Clients.FirstOrDefault(n => n.Id == id));
        var result = await _context.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<FullUserInfo>> GetFullUsers()
    {
        var users = GetAllClients().Result.ToList();
        var accounts = await GetAllAccounts();
        var cards = await GetAllCards();
        var listFullUserInfo = new List<FullUserInfo>();
        foreach (var user in users)
        {
            var account = accounts.FirstOrDefault(n => n.IdClient == user.Id);
            listFullUserInfo.Add(new FullUserInfo
            {
                Client = user,
                Account = account,
                Cards = cards.Where(n => n.NumberAccount == account.Number).ToList()
            });
        }
        return listFullUserInfo.AsEnumerable();
    }
}