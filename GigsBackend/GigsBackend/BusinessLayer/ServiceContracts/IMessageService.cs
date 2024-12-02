using BusinessLayer.Dtos.Request;
using BusinessLayer.Dtos.Response;
using Data.RepositoryContracts;

namespace BusinessLayer.ServiceContracts;

public interface IMessageService
{
    public Task<List<MessageViewModel>> GetMessagesByUserId(Guid userId);
    public Task<List<MessageViewModel>> GetMessagesById(Guid messageId);
    public Task AddMessage(SendMessageRequest request);
}