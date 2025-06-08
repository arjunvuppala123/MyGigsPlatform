namespace GigsService.Infrastructure.Repository
{
    public class GigsRepository(ProjectDbContext context) : IGigsRepository
    {
        private readonly ProjectDbContext _context = context;

        public async Task<Guid> AddAsync(GigsDomainModel gig, CancellationToken cancellationToken = default)
        {
            var entity = gig.Adapt<Gig>();
            entity.Id = Guid.NewGuid();
            _context.Gigs.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
