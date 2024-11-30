using BusinessLayer.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GigsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GendersController(IGenderService genderService) : Controller
{
    private readonly IGenderService _genderService = genderService;
    
    // GET
    [HttpGet]
    public IActionResult GetGenders()
    {
        var result = _genderService.GetGenders();
        if (result.Count <= 0)
            return BadRequest("No genders found");
        return Ok(result);
    }
}