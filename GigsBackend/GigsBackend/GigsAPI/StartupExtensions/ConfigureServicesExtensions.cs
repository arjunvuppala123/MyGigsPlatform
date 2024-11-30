using BusinessLayer.ServiceContracts;
using BusinessLayer.Services;
using Data.Context;
using Data.Repository;
using Data.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace GigsAPI.StartupExtensions;

public static class ConfigureServicesExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //add repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGendersRepository, GendersRepository>();
        services.AddScoped<IRolesRepository, RolesRepository>();
        services.AddScoped<IMessageRepository, MessagesRepository>();
        
        //add services
        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IGenderService, GenderServices>();
        services.AddScoped<IRoleServices, RolesService>();
        
        services.AddDbContext<ProjectDbContext>(opt => 
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}