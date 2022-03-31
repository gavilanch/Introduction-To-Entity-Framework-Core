using EFCoreMovies;
using EFCoreMovies.CompiledModels;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer("name=DefaultConnection", sqlServer => sqlServer.UseNetTopologySuite());
    //options.UseModel(ApplicationDbContextModel.Instance);
    });

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    applicationDbContext.Database.Migrate();
//}

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
