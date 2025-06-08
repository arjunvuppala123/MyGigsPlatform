namespace GigsService.Domain.CQRSObjects.Commands
{
    public record CreateGigCommand(GigsDomainModel Gig) : ICommand<Guid>;
}
