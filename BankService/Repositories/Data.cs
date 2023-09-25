using BankService.Models;

namespace BankService;

public class Data : IData 
{
    public List<Account> Accounts()
    {
        List<Account> accounts =new List<Account>();
        for (int i = 0; i < 50; i++)
        {
            accounts.Add(new Account
            {
                Number = i.ToString(),
                Inn = i
            });
        }
        return accounts;
    }
    public List<Card> Cards()
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < 50; i++)
        {
            cards.Add(new Card
            {
                Number = i.ToString(),
                EndTime = DateTime.Now.AddYears(2),
                Svv = (i+1)*(100+i)
            });
        }
        return cards;
    }
    public List<Client> Clients()
    {
        List<Client> clients = new List<Client>();
        for (int i = 0; i < 50; i++)
        {
            clients.Add(new Client()
            {
                Id = i,
                Name = "Ivan",
                Surname = "Ivanov",
                Patronymic = "Ivanovich",
                Passport = i,
                BirthdayData = DateTime.Now.AddYears(-i)
            });
        }
        return clients;
    }

    public List<FullUserInfo> FullUserInfos()
    {
        List<Client> clients = Clients();
        List<Card> cards = Cards();
        List<Account> accounts = Accounts();
        var fullUserInfo = new List<FullUserInfo>();
        for (int i = 0; i < 50; i++)
        {
            fullUserInfo.Add(
                new FullUserInfo
                {
                    Client = clients[i],
                    Accounts = accounts[i],
                    Cards = cards[i]
                }
            );
        }
        return fullUserInfo;
    }
}