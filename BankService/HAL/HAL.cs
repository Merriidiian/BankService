using System.ComponentModel;
using System.Dynamic;
using BankService.DTOs;
using BankService.Models;

namespace BankService.HAL;

public static class HAL
{
    public static dynamic PaginateAsDynamic(string baseUrl, int index, int count, int total)
    {
        dynamic links = new ExpandoObject();
        links.self = new { href = $"{baseUrl}" };
        if (index < total)
        {
            links.next = new { href = $"{baseUrl}/hal/?index={index + count}" };
            links.final = new { href = $"{baseUrl}/hal/?index={total - (total % count)}&count={count}" };
        }

        if (index > 0)
        {
            links.prev = new { href = $"{baseUrl}/hal/?index={index - count}" };
            links.first = new { href = $"{baseUrl}/hal/?index=0" };
        }

        return links;
    }

    public static dynamic ToResource(this FullUserInfo user, string baseUrl)
    {
        var resource = user.ToDynamic();
        resource._links = new
        {
            account = new
            {
                href = $"{baseUrl}/account/{user.Account}"
            },
            card = new
            {
                href = $"{baseUrl}/card/{user.Cards}"
            },
            client = new
            {
                href = $"{baseUrl}/client/{user.Client.Id}"
            }
        };
        return resource;
    }

    public static dynamic ToDynamic(this object value)
    {
        IDictionary<string, object> result = new ExpandoObject();
        var properties = TypeDescriptor.GetProperties(value.GetType());
        foreach (PropertyDescriptor prop in properties)
        {
            if (Ignore(prop)) continue;
            result.Add(prop.Name, prop.GetValue(value));
        }

        return result;
    }

    private static bool Ignore(PropertyDescriptor prop)
    {
        return prop.Attributes.OfType<System.Text.Json.Serialization.JsonIgnoreAttribute>().Any();
    }
}
