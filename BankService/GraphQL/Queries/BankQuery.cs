using BankService.GraphQL.GraphTypes;
using BankService.Models;
using GraphQL;
using GraphQL.Types;

namespace BankService.GraphQL.Queries;

public class BankQuery : ObjectGraphType
{
    private readonly IDataRepository _repository;

    public BankQuery(IDataRepository repository)
    {
        _repository = repository;

        //Client
        Field<ListGraphType<ClientGraphTypes>>("Clients", "Query to retrieve all clients",
            resolve: GetAllClients);
        Field<ClientGraphTypes>("Client", "Search client by id",
            new QueryArguments(MakeNonNullStringArgument("id", "The ID of the Client")),
            resolve: GetClient);
        
        //Account
        Field<ListGraphType<AccountGraphTypes>>("Accounts", "Query to retrieve all accounts",
            resolve: GetAllAccounts);
        Field<AccountGraphTypes>("Account", "Search account by number",
            new QueryArguments(MakeNonNullStringArgument("number", "The number of the Card")),
            resolve: GetAccount);
        
        //Card
        Field<ListGraphType<CardGraphTypes>>("Cards", "Query to retrieve all cards",
            resolve: GetAllCards);
        Field<CardGraphTypes>("Card", "Search card by number",
            new QueryArguments(MakeNonNullStringArgument("number", "The number of the Card")),
            resolve: GetCard);
    }
    
    private QueryArgument MakeNonNullStringArgument(string name, string description)
    {
        return new QueryArgument<NonNullGraphType<StringGraphType>>
        {
            Name = name, Description = description
        };
    }

    //Client
    private async Task<IEnumerable<Client>> GetAllClients(IResolveFieldContext<object> context) =>
        await _repository.GetAllClients();

    private async Task<Client> GetClient(IResolveFieldContext<object> context)
    {
        var id = context.GetArgument<int>("id");
        var result = await _repository.GetAllClients();
        return result.FirstOrDefault(i => i.Id == id);
    }
    //Account
    private async Task<IEnumerable<Account>> GetAllAccounts(IResolveFieldContext<object> context) =>
        await _repository.GetAllAccounts();

    private async Task<Account> GetAccount(IResolveFieldContext<object> context)
    {
        var number = context.GetArgument<string>("number");
        var result = await _repository.GetAllAccounts();
        return result.FirstOrDefault(i => i.Number == number);
    }
    
    //Card
    private async Task<IEnumerable<Card>> GetAllCards(IResolveFieldContext<object> context) =>
        await _repository.GetAllCards();

    private async Task<Card> GetCard(IResolveFieldContext<object> context)
    {
        var number = context.GetArgument<string>("number");
        var result = await _repository.GetAllCards();
        return result.FirstOrDefault(i => i.Number == number);
    }
}