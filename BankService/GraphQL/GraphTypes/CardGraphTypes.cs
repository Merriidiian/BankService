using BankService.Models;
using GraphQL.Types;

namespace BankService.GraphQL.GraphTypes;

public sealed class CardGraphTypes : ObjectGraphType<Card>
{
    public CardGraphTypes()
    {
        Name = "card";
        Field(c => c.Number).Description("The number of the card, e.g. 1, 2, 3");
    }
}