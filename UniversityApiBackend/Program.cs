//usings to work with entity framework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//connection with data base SQL
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//Add Context to service of builder
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
