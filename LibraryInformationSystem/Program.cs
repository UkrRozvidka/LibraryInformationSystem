using LibraryInformationSystem.BLL.Services;
using LibraryInformationSystem.BLL.Services.Contracts;
using LibraryInformationSystem.LibraryInformationSystem.BLL.Services;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Context;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Repository;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Repository.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBorrowService, BorrowService>();


builder.Services.AddControllers();
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
