using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GigsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController
{
    // GET
    [HttpGet]
    public IActionResult GetMessages()
    {
        return new JsonResult("abc");
    }
    
    
    // POST
    [HttpPost]
    public IActionResult SendMessages()
    {
        return new JsonResult("abc");
    }
}