using BankService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankService.Controllers;

[Produces("application/json")]
[Route("api/bank/card")]
[ApiController]
public class ControllerCard : ControllerBase
{
    private readonly IDataRepository _repository;

    public ControllerCard(IDataRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    private IEnumerable<Card> GetCards()
    {
        return _repository.GetAllCards().Result;
    }

    [HttpGet("{id}")]
    public IActionResult GetCard(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        try
        {
            return Ok(_repository.GetCard(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}