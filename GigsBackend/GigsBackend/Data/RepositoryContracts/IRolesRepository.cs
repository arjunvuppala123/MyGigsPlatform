using DbLayer.Models;

namespace Data.RepositoryContracts;

public interface IRolesRepository
{
    List<Role> GetRoles();
}