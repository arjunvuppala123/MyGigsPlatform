using DbLayer.Models;

namespace Data.RepositoryContracts;

public interface IGendersRepository
{
    List<Gender> GetGenders();
}