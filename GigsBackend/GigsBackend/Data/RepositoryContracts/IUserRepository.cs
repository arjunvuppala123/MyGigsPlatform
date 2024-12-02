using BusinessLayer.Dtos.Request;
using BusinessLayer.Dtos.Response;
using DbLayer.Models;

namespace Data.RepositoryContracts;

public interface IUserRepository
{
    bool SaveUser(SaveUser user);
    User? GetUserProfile(string email);
}