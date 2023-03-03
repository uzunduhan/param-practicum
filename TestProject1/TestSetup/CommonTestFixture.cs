using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Service.Mapper;

namespace TestSetup
{
    public class CommonTestFixture
    {
        public DatabaseContext context {get; set;}
        public IMapper Mapper {get; set;}
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDb").Options;
            context = new DatabaseContext(options);
            context.Database.EnsureCreated();
            context.AddMovies();
 
            context.SaveChanges();

            Mapper = new MapperConfiguration(cfg=>{cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }

}