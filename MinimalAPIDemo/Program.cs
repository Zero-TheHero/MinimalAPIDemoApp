using CoreBusiness.Repositories;
using MinimalAPIDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
    builder.Services.AddSingleton<IUserRepository, Plugins.InMemoryRepository.UserRepository>();
else
{
    #if DEBUG
        builder.Services.AddSingleton<IUserRepository, Plugins.InMemoryRepository.UserRepository>();
    #else
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<IUserRepository, Plugins.SqlRepository.UserRepository>();
    #endif
}

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.ConfigureApiUser();

app.Run();

public partial class Program { }