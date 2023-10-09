using BankService.Models;
using GraphQL.Types;

namespace BankService.GraphQL.GraphTypes;

public sealed class AccountGraphTypes: ObjectGraphType<Account>
{
    public AccountGraphTypes()
    {
        Name = "account";
        Field(c => c.Number).Description("The number of the account, e.g. 1, 2, 3");
        Field(c => c.IdClient);
        Field(c => c.Inn);
    }
}