using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Task_10.Data;
using Task_10.Services;
using Task_10.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(opt => opt.UseInMemoryDatabase("BooksDb"));
builder.Services.AddScoped<IBookService, BookService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandling>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
