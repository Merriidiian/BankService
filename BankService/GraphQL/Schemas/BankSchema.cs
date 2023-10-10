using BankService.GraphQL.Mutations;
using BankService.GraphQL.Queries;
using GraphQL.Types;

namespace BankService.GraphQL.Schemas;

public class BankSchema : Schema
{
    public BankSchema(IDataRepository repository)
    {
        Query = new BankQuery(repository);
        Mutation = new BankMutation(repository);
    }
}