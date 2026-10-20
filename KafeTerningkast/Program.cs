using KafeTerningkast.Components;
using KafeTerningkast.Models;
using KafeTerningkast.Services;

var builder = WebApplication.CreateBuilder(args);


// Register GameService as a signleton to share game data across the app.
// Shared by the whole app
builder.Services.AddSingleton<GameService>();

// Register GameNigthState as 'scoped' so each user has their own game-night state.
// 
builder.Services.AddScoped<GameNightState>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();