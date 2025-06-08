namespace GigsService.Application.ServiceContracts
{
    public interface ICreateGigsService
    {
        Task<Guid> CreateAsync(CreateGigDto dto, CancellationToken cancellationToken = default);
    }
}
