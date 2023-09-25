using BankService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankService.Controllers;

[Produces("application/json")]
[Route("api/bank/account")]
[ApiController]
public class ControllerAccount : ControllerBase
{
    private readonly IDataRepository _repository;

    public ControllerAccount(IDataRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    private IEnumerable<Account> GetAccounts()
    {
        return _repository.GetAllAccounts().Result;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAccount(string id)
    {
        if (id == null)
        {
            return NotFound();
        }
        try
        {
            return Ok(_repository.GetAccount(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}