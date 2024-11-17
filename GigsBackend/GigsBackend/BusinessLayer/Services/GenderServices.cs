using BusinessLayer.ServiceContracts;
using Data.RepositoryContracts;
using DbLayer.Models;

namespace BusinessLayer.Services;

public class GenderServices(IGendersRepository gendersRepository): IGenderService
{
    private readonly IGendersRepository _gendersRepository = gendersRepository;
    
    public List<Gender> GetGenders()
    {
        return _gendersRepository.GetGenders();
    }
}