using BankService.Models;
using GraphQL.Types;

namespace BankService.GraphQL.GraphTypes;

public sealed class ClientGraphTypes : ObjectGraphType<Client> {
    public ClientGraphTypes()
    {
        Name = "client";
        Field(c => c.Id).Description("The id of the client, e.g. 1, 2, 3");
    }
}