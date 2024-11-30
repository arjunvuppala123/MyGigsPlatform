using BusinessLayer.Dtos.Request;
using BusinessLayer.Dtos.Response;
using BusinessLayer.ServiceContracts;
using Data.RepositoryContracts;
using DbLayer.Models;

namespace BusinessLayer.Services;

public class UserServices(IUserRepository userRepository) : IUserServices
{
    private readonly IUserRepository _userRepository = userRepository;

    public bool SaveUsers(SaveUser user)
    {
        return _userRepository.SaveUser(user);
    }

    public UserProfileViewModel? GetUserInfo(string? email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return null;
        }
        
        var result = _userRepository.GetUserProfile(email);
        if (result == null)
            return null;

        return new UserProfileViewModel()
        {
            Name = result.Name,
            Email = result.Email,
            Gender = result.Gender.Name,
            Role = result.Role.RoleDescription,
            ProfilePicture = result.ProfilePicture
        };
    }
}