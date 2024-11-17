using DbLayer.Models;

namespace BusinessLayer.ServiceContracts;

public interface IGenderService
{
    List<Gender> GetGenders();
}