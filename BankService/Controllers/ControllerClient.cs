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
    private IEnumerable<Client> GetClients()
    {
        return _repository.GetAllClients().Result;
    }

    [HttpGet("{id}")]
    public IActionResult GetClient(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        try
        {
            return Ok(_repository.GetClient(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}