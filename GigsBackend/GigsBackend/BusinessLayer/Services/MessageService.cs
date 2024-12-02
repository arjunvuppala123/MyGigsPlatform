using BusinessLayer.Dtos.Request;
using BusinessLayer.Dtos.Response;
using BusinessLayer.ServiceContracts;
using Data.RepositoryContracts;
using DbLayer.Models;

namespace BusinessLayer.Services;

public class MessageService(IMessageRepository messageRepository) : IMessageService
{
    private readonly IMessageRepository _messageRepository = messageRepository;

    public async Task<List<MessageViewModel>> GetMessagesByUserId(Guid userId)
    {
        var messages = await _messageRepository.GetFirstMessagesForReceiverAsync(userId);
        if (messages.Any())
        {
            List<MessageViewModel> result = messages.Select(m => new MessageViewModel
            {
                Id = m.Id,
                Name = m.Sender.Name,
                ProfilePhoto = m.Sender.ProfilePicture, 
                Message = m.MessageContent, 
                SentAt = m.SentAt
            }).ToList();
            
            return result;
        }

        return new List<MessageViewModel>();
    }

    public async Task<List<MessageViewModel>> GetMessagesById(Guid messageId)
    {
        var messages = await _messageRepository.GetMessagesBetweenUsersAsync(messageId);
        if (messages.Any())
        {
            List<MessageViewModel> result = messages.Select(m => new MessageViewModel
            {
                Id = m.Id,
                Name = m.Sender.Name,
                ProfilePhoto = m.Sender.ProfilePicture, 
                Message = m.MessageContent, 
                SentAt = m.SentAt
            }).ToList();
            
            return result;
        }

        return new List<MessageViewModel>();
    }

    public async Task AddMessage(SendMessageRequest request)
    {
        await _messageRepository.AddMessageAsync(new Message()
        {
            GigId = request.GigId,
            SenderId = request.SenderId,
            RecieverId = request.ReceiverId,
            SentAt = DateTime.UtcNow,
            MessageContent = request.Content
        });
    }
}