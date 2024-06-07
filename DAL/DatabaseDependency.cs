using DigitasChallenge.DAL.Repositories;
using DigitasChallenge.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitasChallenge.DAL
{
    public static class DatabaseDependency
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DigitasContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly(typeof(DigitasContext).Assembly.FullName))
                    );
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            // Técnica de composição = https://www.youtube.com/watch?v=LfiezdBs318
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITasksRepository, TasksRepository>();
        }
    }
}
