using BusinessLayer.Dtos.Request;
using DbLayer.Models;

namespace Data.RepositoryContracts;

public interface IUserRepository
{
    bool SaveUser(SaveUser user);
    User? GetUserProfile(string email);
}