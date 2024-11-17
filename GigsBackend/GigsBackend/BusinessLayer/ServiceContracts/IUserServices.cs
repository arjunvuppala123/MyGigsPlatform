using BusinessLayer.Dtos.Response;
using DbLayer.Models;

namespace BusinessLayer.ServiceContracts;

public interface IUserServices
{
    public bool SaveUsers(User user);
    public UserProfileViewModel? GetUserInfo(string? email);
}