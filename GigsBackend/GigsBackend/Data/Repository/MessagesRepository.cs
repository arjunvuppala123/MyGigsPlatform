using Data.Context;
using Data.RepositoryContracts;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class MessagesRepository(ProjectDbContext db): IMessageRepository
{
    private readonly ProjectDbContext _db = db;


    public async Task<IEnumerable<Message>> GetFirstMessagesForReceiverAsync(Guid receiverId)
    {
        return await _db.Messages
            .Where(m => m.RecieverId == receiverId)
            .GroupBy(m => m.SenderId)
            .Select(g => g.OrderBy(m => m.SentAt).First())
            .ToListAsync();
    }

    public async Task<IEnumerable<Message>> GetMessagesBetweenUsersAsync(Guid senderId, Guid receiverId)
    {
        return await _db.Messages
            .Where(m => 
                (m.SenderId == senderId && m.RecieverId == receiverId) || 
                (m.SenderId == receiverId && m.RecieverId == senderId)
            )
            .OrderBy(m => m.SentAt)
            .ToListAsync();
    }

    public async Task AddMessageAsync(Message message)
    {
        await _db.Messages.AddAsync(message);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}