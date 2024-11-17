using Data.Context;
using Data.RepositoryContracts;
using DbLayer.Models;

namespace Data.Repository;

public class GendersRepository(ProjectDbContext db): IGendersRepository
{
    private readonly ProjectDbContext _db = db;
    
    public List<Gender> GetGenders()
    {
        return _db.Genders.ToList();
    }
}