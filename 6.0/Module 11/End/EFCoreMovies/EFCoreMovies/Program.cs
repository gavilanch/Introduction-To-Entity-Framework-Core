using EFCoreMovies;
using EFCoreMovies.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserServiceFake>();
builder.Services.AddScoped<IChangeTrackerEventHandler, ChangeTrackerEventHandler>();

builder.Services.AddSingleton<Singleton>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer("name=DefaultConnection", sqlServer => sqlServer.UseNetTopologySuite());
});


//builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
