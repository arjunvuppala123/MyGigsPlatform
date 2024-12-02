using BusinessLayer.Dtos.Request;
using BusinessLayer.Dtos.Response;
using Data.Context;
using Data.RepositoryContracts;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class UserRepository(ProjectDbContext db) : IUserRepository
{
    private readonly ProjectDbContext _db = db;

    public bool CheckIfUserExists(string email)
    {
        return _db.Users.Any(user => user.Email == email);
    }
    
    public bool SaveUser(SaveUser user)
    {
        var isInsert = CheckIfUserExists(user.Email);
        if (!isInsert)
        {
            var insertUser = new User()
            {
                RoleId = user.RoleId,
                GenderId = user.GenderId,
                Name = user.Name,
                Email = user.Email,
                ProfilePicture = string.Empty,
                IsUserProfileComplete = true
            };
            _db.Users.Add(insertUser);
        }
        else
        {
            var updateUser = GetUserProfile(user.Email);
            updateUser.GenderId = user.GenderId;
            updateUser.UpdatedAt = DateTime.UtcNow;
            updateUser.Name = user.Name;
            updateUser.IsUserProfileComplete = true;
        }
        var affectedRows = _db.SaveChanges();
        return affectedRows > 0;
    }

    public User? GetUserProfile(string email)
    {
        return _db.Users
            .Include(user => user.Role)
            .Include(user => user.Gender)
            .FirstOrDefault(user => user.Email == email);
    }
}