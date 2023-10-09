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
    public async Task<IActionResult> GetAccounts()
    {
        return Ok(await _repository.GetAllAccounts());
    }

    [HttpGet]
    [Route("{number}")]
    public async Task<IActionResult> GetAccount(string number)
    {
        try
        {
            var result = await _repository.GetAllAccounts();
            return Ok(result.FirstOrDefault(n => n.Number == number));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    [Route("{number}")]
    public async Task<IActionResult> PostAccount(string number, Account account)
    {
        try
        {
            return Ok(await _repository.PostAccount(number, account));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> PutAccount(Account account)
    {
        try
        {
            return Ok(await _repository.PutAccount(account));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAccount(string number)
    {
        try
        {
            return Ok(await _repository.DeleteAccount(number));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}