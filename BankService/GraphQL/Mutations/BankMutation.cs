using BankService.GraphQL.GraphTypes;
using BankService.Models;
using GraphQL;
using GraphQL.Types;

namespace BankService.GraphQL.Mutations;

public class BankMutation : ObjectGraphType
{
    private readonly IDataRepository _repository;

    public BankMutation(IDataRepository repository)
    {
        _repository = repository;

        //PUT
        //Client
        Field<ClientGraphTypes>(
            "createClient",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "surname" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "patronymic" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "passport" },
                new QueryArgument<NonNullGraphType<DateTimeGraphType>> { Name = "birthdayData" }
            ),
            resolve: context =>
            {
                var name = context.GetArgument<string>("name");
                var surname = context.GetArgument<string>("surname");
                var patronymic = context.GetArgument<string>("patronymic");
                var passport = context.GetArgument<int>("passport");
                var birthdayData = context.GetArgument<DateTime>("birthdayData");

                var client = new Client
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Passport = passport,
                    BirthdayData = birthdayData
                };
                try
                {
                    _repository.PutClient(client);
                    return client;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );

        //Account
        Field<AccountGraphTypes>(
            "createAccount",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "number" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "idClient" },
                new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "inn" }
            ),
            resolve: context =>
            {
                var number = context.GetArgument<string>("number");
                var idClient = context.GetArgument<int>("idClient");
                var inn = context.GetArgument<long>("inn");

                var account = new Account
                {
                    Number = number,
                    IdClient = idClient,
                    Inn = inn
                };
                try
                {
                    _repository.PutAccount(account);
                    return account;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );

        //Card
        Field<CardGraphTypes>(
            "createCard",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "number" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "numberAccount" },
                new QueryArgument<NonNullGraphType<DateTimeGraphType>> { Name = "endTime" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "svv" }
            ),
            resolve: context =>
            {
                var number = context.GetArgument<string>("number");
                var numberAccount = context.GetArgument<string>("numberAccount");
                var endTime = context.GetArgument<DateTime>("endTime");
                var svv = context.GetArgument<int>("svv");

                var card = new Card
                {
                    Number = number,
                    NumberAccount = numberAccount,
                    EndTime = endTime,
                    Svv = svv
                };
                try
                {
                    _repository.PutCard(card);
                    return card;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );

        //POST
        //Client
        Field<ClientGraphTypes>(
            "editClient",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "surname" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "patronymic" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "passport" },
                new QueryArgument<NonNullGraphType<DateTimeGraphType>> { Name = "birthdayData" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                var name = context.GetArgument<string>("name");
                var surname = context.GetArgument<string>("surname");
                var patronymic = context.GetArgument<string>("patronymic");
                var passport = context.GetArgument<int>("passport");
                var birthdayData = context.GetArgument<DateTime>("birthdayData");

                var client = new Client
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Passport = passport,
                    BirthdayData = birthdayData
                };
                try
                {
                    _repository.PostClient(id, client);
                    return client;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );
        
        //Account
        Field<AccountGraphTypes>(
            "editAccount",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "number" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "idClient" },
                new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "inn" }
            ),
            resolve: context =>
            {
                var number = context.GetArgument<string>("number");
                var idClient = context.GetArgument<int>("idClient");
                var inn = context.GetArgument<long>("inn");

                var account = new Account
                {
                    Number = number,
                    IdClient = idClient,
                    Inn = inn
                };
                try
                {
                    _repository.PostAccount(number,account);
                    return account;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );
        
        //Card
        Field<CardGraphTypes>(
            "editCard",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "number" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "numberAccount" },
                new QueryArgument<NonNullGraphType<DateTimeGraphType>> { Name = "endTime" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "svv" }
            ),
            resolve: context =>
            {
                var number = context.GetArgument<string>("number");
                var numberAccount = context.GetArgument<string>("numberAccount");
                var endTime = context.GetArgument<DateTime>("endTime");
                var svv = context.GetArgument<int>("svv");

                var card = new Card
                {
                    Number = number,
                    NumberAccount = numberAccount,
                    EndTime = endTime,
                    Svv = svv
                };
                try
                {
                    _repository.PostCard(number,card);
                    return card;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );
        
        //Delete
        Field<ClientGraphTypes>(
            "deleteClient",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");

                try
                {
                    _repository.DeleteClient(id);
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );
        
        //Account
        Field<AccountGraphTypes>(
            "deleteAccount",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "number" }
            ),
            resolve: context =>
            {
                var number = context.GetArgument<string>("number");
                
                try
                {
                    _repository.DeleteAccount(number);
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );
        
        //Card
        Field<CardGraphTypes>(
            "deleteCard",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "number" }
            ),
            resolve: context =>
            {
                var number = context.GetArgument<string>("number");
                
                try
                {
                    _repository.DeleteCard(number);
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error. {e.Message}");
                }
            }
        );
    }
}