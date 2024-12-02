using Data.RepositoryContracts;
using DbLayer.Models;
using Microsoft.AspNetCore.SignalR;

namespace BusinessLayer.Services;

public class MessagesHub : Hub
{
    private readonly IMessageRepository _messageRepository;

    public MessagesHub(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task SendMessage(Guid senderId, Guid receiverId, string content)
    {
        var message = new Message
        {
            GigId = new Guid("d10b4730-a10d-4fc3-8593-1d2ef0e3b5be"),
            SenderId = senderId,
            RecieverId = receiverId,
            MessageContent = content,
            SentAt = DateTime.UtcNow
        };

        await _messageRepository.AddMessageAsync(message);
        await _messageRepository.SaveChangesAsync();
        
        await Clients.User(receiverId.ToString()).SendAsync("ReceiveMessage", message);
    }

    public async Task GetMessages(Guid messageId)
    {
        var messages = await _messageRepository.GetMessagesBetweenUsersAsync(messageId);
        await Clients.Caller.SendAsync("ReceiveMessages", messages);
    }
}