using BankService.GraphQL.GraphTypes;
using BankService.Models;
using GraphQL;
using GraphQL.Types;

namespace BankService.GraphQL.Queries;

public class ClientQuery : ObjectGraphType
{
    private readonly IDataRepository _repository;

    public ClientQuery(IDataRepository repository)
    {
        _repository = repository;
        Field<ListGraphType<ClientGraphTypes>>("Clients", "Query to retrieve all clients",
            resolve: GetAllClients);
        Field<ClientGraphTypes>("Client", "Search client by id",
            new QueryArguments(MakeNonNullStringArgument("id", "The ID of the Client")),
            resolve: GetClient);
    }

    private QueryArgument MakeNonNullStringArgument(string name, string description)
    {
        return new QueryArgument<NonNullGraphType<StringGraphType>>
        {
            Name = name, Description = description
        };
    }

    private async Task<IEnumerable<Client>> GetAllClients(IResolveFieldContext<object> context) =>
        await _repository.GetAllClients();

    private async Task<Client> GetClient(IResolveFieldContext<object> context)
    {
        var id = context.GetArgument<int>("id");
        var result = await _repository.GetAllClients();
        return result.FirstOrDefault(i => i.Id == id);
    }
}