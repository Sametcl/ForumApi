using Forum.Api.Registration;
using Forum.Core;
using Forum.Core.Exceptions;
using Forum.Data;
using Forum.Data.Context;
using Forum.Entity.Entities;
using Forum.Service;
using Forum.Service.Describer;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddData(builder.Configuration);
builder.Services.AddService();
builder.Services.AddCore();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
      {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
      })
                 .AddEntityFrameworkStores<AppDbContext>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddDefaultTokenProviders();


builder.Services.AddJwtAuthentication(builder.Configuration);//jwt conf
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
