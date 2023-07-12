using DataAccess.DbAccess;
using MinimalAPIDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

if (builder.Environment.IsDevelopment())
    builder.Services.AddSingleton<IUserData, InMemoryUserData>();
else
    builder.Services.AddSingleton<IUserData, SqlUserData>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
    app.ConfigureApiTest();
else
    app.ConfigureApiUser();

app.Run();

public partial class Program { }