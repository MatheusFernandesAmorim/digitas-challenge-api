using AutoMapper;
using DigitasChallenge.BLL.Models;
using DigitasChallenge.BLL.Services;
using DigitasChallenge.BLL.Services.Interfaces;
using DigitasChallenge.BLL.Validators;
using DigitasChallenge.BLL.Validators.Interfaces;
using DigitasChallenge.DAL.Entities;

namespace DigitasChallenge.BLL
{
    public static class ServicesDependency
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CompleteTasksModel,Tasks>();
                cfg.CreateMap<Tasks,CompleteTasksModel>();
                cfg.CreateMap<SimpleTasksModel, Tasks>();                
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITasksValidator, TasksValidator>();
            services.AddScoped<ITasksService, TasksService>();
        }
    }
}