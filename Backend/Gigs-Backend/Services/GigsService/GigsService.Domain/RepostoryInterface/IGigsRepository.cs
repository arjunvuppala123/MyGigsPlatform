namespace GigsService.Domain.RepostoryInterface
{
    public interface IGigsRepository
    {
        public Task<Guid> AddAsync(GigsDomainModel gig, CancellationToken cancellationToken = default);
    }
}
