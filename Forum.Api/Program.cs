using Forum.Core;
using Forum.Core.Exceptions;
using Forum.Data;
using Forum.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddData(builder.Configuration);
builder.Services.AddService();
builder.Services.AddCore();

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
app.UseRouting();
app.ConfigureExceptionHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
