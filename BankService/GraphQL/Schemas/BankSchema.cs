using BankService.GraphQL.Queries;
using GraphQL.Types;

namespace BankService.GraphQL.Schemas;

public class BankSchema : Schema
{
    public BankSchema(IDataRepository repository)
    {
        Query = new ClientQuery(repository);
    }
}