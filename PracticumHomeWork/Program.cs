using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.UnitOfWork.Abstract;
using PracticumHomeWork.UnitOfWork.Concrete;
using System.Reflection;
using PracticumHomeWork.Extensions;
using PracticumHomeWork.Middlewares;
using PracticumHomeWork.Services;
using PracticumHomeWork.DBOperations;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddDebug();
builder.Logging.AddConsole();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: "apiorigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));



//builder.Services.AddDbContext<DatabaseContext>(optins => optins.UseInMemoryDatabase(databaseName: "ParamDb"));

builder.Services.AddDbContext<DatabaseContext>(
       options => options.UseSqlServer("name=ConnectionStrings:SqlServerConnectionString"));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    //DataGenerator.Initialize(services);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("apiorigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseRequestResponseMiddleware();


app.MapControllers();

app.Run();
