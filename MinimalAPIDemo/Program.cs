using DataAccess.DbAccess;
using MinimalAPIDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IUserData, UserData>();

var app = builder.Build();

app.Logger.LogInformation("Started");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.Logger.LogInformation("Configure Endpoints");
app.ConfigureApi();

app.Run();
