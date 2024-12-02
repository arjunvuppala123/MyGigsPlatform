using BusinessLayer.Dtos.Request;
using BusinessLayer.Dtos.Response;
using DbLayer.Models;

namespace BusinessLayer.ServiceContracts;

public interface IUserServices
{
    public bool SaveUsers(SaveUser user);
    public UserProfileViewModel? GetUserInfo(string? email);
    public UserCheckModel? UserCheck(string? email);
}