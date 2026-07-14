using Microsoft.Extensions.DependencyInjection;
using Nexa.Localization.Abstractions;
using Nexa.Localization.B.Components;
using Nexa.Localization.Extensions;
using Nexa.Localization.Models;
using Nexa.Localization.Runtime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddNexaLocalization(options =>
{
    options.DefaultCulture = "ckb";
    options.FallbackCulture = "en";

    options.AddDefaultLanguages();
});

var app = builder.Build();

await app.Services.InitializeNexaLocalizationAsync();
 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
