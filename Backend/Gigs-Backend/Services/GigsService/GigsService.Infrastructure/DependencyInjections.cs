namespace GigsService.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<ProjectDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("CommonUtilitesLibrary"))); 

            //Add RepositoryMappings
            services.AddScoped<IGigsRepository, GigsRepository>();
            return services;
        }
    }
}
