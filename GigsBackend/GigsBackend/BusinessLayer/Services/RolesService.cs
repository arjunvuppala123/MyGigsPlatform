using BusinessLayer.ServiceContracts;
using Data.RepositoryContracts;
using DbLayer.Models;

namespace BusinessLayer.Services;

public class RolesService(IRolesRepository rolesRepository): IRoleServices
{
    private readonly IRolesRepository _rolesRepository = rolesRepository;
    
    public List<Role> GetRoles()
    {
        return _rolesRepository.GetRoles();
    }
}