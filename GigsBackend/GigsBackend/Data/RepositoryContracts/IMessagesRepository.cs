using DbLayer.Models;

namespace Data.RepositoryContracts;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetFirstMessagesForReceiverAsync(Guid receiverId);
    Task<IEnumerable<Message>> GetMessagesBetweenUsersAsync(Guid messageId);
    Task AddMessageAsync(Message message);
    Task SaveChangesAsync();
}
