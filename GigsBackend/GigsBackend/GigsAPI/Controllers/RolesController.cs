using BusinessLayer.ServiceContracts;
using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace GigsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController(IRoleServices services) : Controller
{
    private readonly IRoleServices roleServices = services;
    
    // GET
    [HttpGet]
    public IActionResult GetGenders()
    {
        var result = roleServices.GetRoles();
        if (result.Count <= 0)
            return BadRequest("No roles found");
        return Ok(result);
    }
}