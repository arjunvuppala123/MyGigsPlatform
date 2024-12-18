using BusinessLayer.Dtos.Request;
using BusinessLayer.Dtos.Response;
using BusinessLayer.ServiceContracts;
using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace GigsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserServices services) : Controller
{
    private readonly IUserServices _services = services;

    [HttpGet]
    public IActionResult? UserGetUserInfo([FromQuery] string? email)
    {
        var result = _services.GetUserInfo(email);
        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult SaveUserInfo([FromBody] SaveUser? user)
    {
        var result = _services.SaveUsers(user);
        if (result)
            return Ok(result);
        return NotFound(result);
    }

    [HttpPost("UserCheck")]
    public IActionResult UserCheck([FromQuery] string email)
    {
        var checkResult = _services.UserCheck(email);
        return Ok(checkResult ?? new UserCheckModel());
    }
}