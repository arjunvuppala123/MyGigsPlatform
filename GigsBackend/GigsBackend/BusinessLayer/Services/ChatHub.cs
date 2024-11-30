using Data.RepositoryContracts;
using DbLayer.Models;
using Microsoft.AspNetCore.SignalR;

namespace BusinessLayer.Services;

public class ChatHub: Hub
{
    private readonly IMessageRepository _messageRepository;

    public ChatHub(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    
    public async Task SendMessage(Guid ReceiverId, Guid SenderId, string message)
    {
        var newMessage = new Message()
        {
            SenderId = SenderId,
            RecieverId = ReceiverId,
            SentAt = DateTime.UtcNow,
            MessageContent = message
        };
        
        await _messageRepository.AddMessageAsync(newMessage);
        await _messageRepository.SaveChangesAsync();
        
        await Clients.User(ReceiverId.ToString()).SendAsync("ReceiveMessage", SenderId, message);
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        return base.OnDisconnectedAsync(exception);
    }
}