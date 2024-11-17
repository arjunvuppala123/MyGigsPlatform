using DbLayer.Models;

namespace BusinessLayer.ServiceContracts;

public interface IRoleServices
{
    List<Role> GetRoles();
}