using BankService.HAL;
using Microsoft.AspNetCore.Mvc;

namespace BankService.Controllers;

[Route("api/bank")]
[ApiController]
public class ControllerHAL : ControllerBase
{
    private readonly IDataRepository _repository;
    const int PAGE_SIZE = 5;
    private const string url = "/api/bank";

    public ControllerHAL(IDataRepository repository)
    {
        _repository = repository;
    }
    

    // GET: api/bank/hal
    [Route("hal")]
    [HttpGet]
    [Produces("application/hal+json")]
    public async Task<IActionResult> Get(int index = 0, int count = PAGE_SIZE)
    {
        var items = _repository.GetAllUsersInfo().Result.Skip(index).Take(count)
            .Select(v => v.ToResource(url));
        var total = _repository.GetAllUsersInfo().Result.Count();
        var _links = HAL.HAL.PaginateAsDynamic(url, index, count, total);
        var result = new
        {
            _links,
            count,
            total,
            index,
            items
        };
        return Ok(result);
    }
    
}