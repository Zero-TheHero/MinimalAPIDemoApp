using DataAccess.DbAccess;
using MinimalAPIDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IUserData, SqlUserData>();
//builder.Services.AddSingleton<IUserData, InMemoryAccess>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.ConfigureApiUser();
app.ConfigureApiTest();

app.Run();

public partial class Program { }