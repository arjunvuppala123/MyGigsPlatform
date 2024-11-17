using DbLayer.Models;

namespace Data.RepositoryContracts;

public interface IUserRepository
{
    bool SaveUser(User user);
    User? GetUserProfile(string email);
}