using DataAccess.DbAccess;
using MinimalAPIDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
    builder.Services.AddSingleton<IUserData, InMemoryUserData>();
else
{
    builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
    builder.Services.AddSingleton<IUserData, SqlUserData>();
}

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.ConfigureApiUser();

app.Run();

public partial class Program { }