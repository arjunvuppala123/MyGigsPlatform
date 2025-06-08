namespace GigsService.Application.Services
{
    public class CreateGigsService : ICreateGigsService
    {
        private readonly ISender _sender;

        public CreateGigsService(ISender sender)
        {
            _sender = sender;
        }

        public async Task<Guid> CreateAsync(CreateGigDto dto, CancellationToken cancellationToken)
        {
            var domainObject = dto.Adapt<GigsDomainModel>();
            return await _sender.Send(new CreateGigCommand(domainObject), cancellationToken);
        }
    }
}
