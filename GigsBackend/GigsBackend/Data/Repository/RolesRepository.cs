using Data.Context;
using Data.RepositoryContracts;
using DbLayer.Models;

namespace Data.Repository;

public class RolesRepository(ProjectDbContext db): IRolesRepository
{
    private readonly ProjectDbContext _db = db;
    
    public List<Role> GetRoles()
    {
        return _db.Roles.ToList();
    }
}