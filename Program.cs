using Microsoft.EntityFrameworkCore;
using Books.Data;
using Books.Interfaces;
using Books.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("MotorcycleDb")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMvc();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
