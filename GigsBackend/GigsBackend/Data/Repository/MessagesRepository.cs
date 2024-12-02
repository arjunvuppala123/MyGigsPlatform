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
            .Include(m => m.Sender) // Includes the Sender User
            .Include(m => m.Receiver) // Includes the Receiver User
            .Include(m => m.Gig) // Includes the related Gig
            .GroupBy(m => m.SenderId)
            .Select(g => g.OrderBy(m => m.SentAt).First())
            .ToListAsync();
    }

    public async Task<IEnumerable<Message>> GetMessagesBetweenUsersAsync(Guid messageId)
    {
        return await _db.Messages
            .Where(m => m.Id == messageId)
            .Include(m => m.Sender) // Includes the Sender User
            .Include(m => m.Receiver) // Includes the Receiver User
            .Include(m => m.Gig) // Includes the related Gig
            .OrderBy(m => m.SentAt) // Orders by SentAt
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