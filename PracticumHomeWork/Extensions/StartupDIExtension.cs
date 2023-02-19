using AutoMapper;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.Repository.Concrete;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Concrete;
using PracticumHomeWork.Service.Abstract;
using PracticumHomeWork.Service.Concrete;
using PracticumHomeWork.Service.Mapper;

namespace PracticumHomeWork.Extensions
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddScoped<IGenericRepository<Movie>, GenericRepository<Movie>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();


            //services.AddScoped<IAccountRepository, AccountRepository>();
            //services.AddScoped<IPersonRepository, PersonRepository>();


            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();


            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
