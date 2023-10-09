using BankService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankService.Controllers;

[Produces("application/json")]
[Route("api/bank/client")]
[ApiController]
public class ControllerClient : ControllerBase
{
    private readonly IDataRepository _repository;

    public ControllerClient(IDataRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        return Ok(await _repository.GetAllClients());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetClient(int id)
    {
        try
        {
            var result = await _repository.GetAllClients();
            return Ok(result.FirstOrDefault(n => n.Id == id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    [Route("{id}")]
    public async Task<IActionResult> PostClient(int id, Client client)
    {
        try
        {
            return Ok(await _repository.PostClient(id, client));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> PutClient(Client client)
    {
        try
        {
            return Ok(await _repository.PutClient(client));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteClient(int id)
    {
        try
        {
            return Ok(await _repository.DeleteClient(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}