using Core.Business.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
if (builder.Environment.IsDevelopment())
    builder.Services.AddSingleton<IUserRepository, Plugins.InMemoryRepository.UserRepository>();
else
{
    #if DEBUG
        builder.Services.AddSingleton<IUserRepository, Plugins.InMemoryRepository.UserRepository>();
    #else
        builder.Services.AddSingleton<ISqlRepository, Plugins.SqlRepository.SqlRepository>();
        builder.Services.AddSingleton<IUserRepository, Plugins.SqlRepository.UserRepository>();
    #endif
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
