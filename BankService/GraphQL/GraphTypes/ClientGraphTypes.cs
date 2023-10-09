using BankService.Models;
using GraphQL.Types;

namespace BankService.GraphQL.GraphTypes;

public sealed class ClientGraphTypes : ObjectGraphType<Client> {
    public ClientGraphTypes()
    {
        Name = "client";
        Field(c => c.Id).Description("The id of the client, e.g. 1, 2, 3");
        Field(c => c.Name);
        Field(c => c.Surname);
        Field(c => c.Patronymic);
        Field(c => c.BirthdayData);
        Field(c => c.Passport);
        
    }
}