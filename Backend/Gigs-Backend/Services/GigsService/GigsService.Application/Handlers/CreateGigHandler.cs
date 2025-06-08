namespace GigsService.Application.Handlers
{
    public class CreateGigHandler(IGigsRepository repo) : ICommandHandler<CreateGigCommand, Guid>
    {
        private readonly IGigsRepository _repo = repo;

        public async Task<Guid> Handle(CreateGigCommand request, CancellationToken cancellationToken)
        {
            return await _repo.AddAsync(request.Gig, cancellationToken);
        }
    }
}
