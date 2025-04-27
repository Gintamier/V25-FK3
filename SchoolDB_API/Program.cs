using Microsoft.EntityFrameworkCore;
using SchoolDB_API.Interfaces;
using SchoolDB_API.Repositories;
using SchoolDB_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Allow JSON cycles (ReferenceHandler.Preserve)
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

// 🔥 REGISTER your IRepository<> so the controller can use it
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 🔥 FIX: Register SchoolContext with SQLite
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlite("Data Source=school.db"));

// Swagger etc.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();