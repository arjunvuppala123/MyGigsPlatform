using BusinessLayer.Dtos.Request;
using BusinessLayer.Dtos.Response;
using BusinessLayer.ServiceContracts;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GigsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IHubContext<MessagesHub> _hubContext;

    public MessagesController(IMessageService messageService, IHubContext<MessagesHub> hubContext)
    {
        _messageService = messageService;
        _hubContext = hubContext;
    }
    
    [HttpGet("messageHistory")]
    public async Task<IActionResult> GetMessageHistory([FromQuery] Guid userId)
    {
        if (userId == Guid.Empty)
            return BadRequest(new { error = "UserId cannot be empty." });

        var result = await _messageService.GetMessagesByUserId(userId);
        if (result == null || !result.Any())
            return NotFound(new { message = "No messages found for the specified user." });

        return Ok(result);
    }
    
    [HttpGet("messages")]
    public async Task<IActionResult> GetMessagesByMessageId([FromQuery] Guid messageId)
    {
        if (messageId == Guid.Empty)
            return BadRequest(new { error = "MessageId cannot be empty." });

        var result = await _messageService.GetMessagesById(messageId);
        if (result == null)
            return NotFound(new { message = "Message not found." });

        return Ok(result);
    }

    [HttpPost("Send")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
    {
        try
        {
            await _messageService.AddMessage(request);
            await _hubContext.Clients.User(request.ReceiverId.ToString()).SendAsync("ReceiveMessage", request);
            return new JsonResult(new { StatusCode = 200, message = "Message sent successfully." });
        }
        catch (Exception e)
        {
            return new JsonResult(new { StatusCode = 500, message = "An error occured while sending a message." });
        }
    }
}
