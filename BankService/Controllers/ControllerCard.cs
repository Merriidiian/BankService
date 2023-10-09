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
    public async Task<IActionResult> GetCards()
    {
        return Ok(await _repository.GetAllCards());
    }

    [HttpGet]
    [Route("{number}")]
    public async Task<IActionResult> GetCard(string number)
    {
        try
        {
            var result = await _repository.GetAllCards();
            return Ok(result.FirstOrDefault(n => n.Number == number));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    [Route("{number}")]
    public async Task<IActionResult> PostCard(string number, Card card)
    {
        try
        {
            return Ok(await _repository.PostCard(number, card));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> PutCard(Card card)
    {
        try
        {
            return Ok(await _repository.PutCard(card));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCard(string number)
    {
        try
        {
            return Ok(await _repository.DeleteCard(number));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}