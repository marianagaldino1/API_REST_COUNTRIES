using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



var apiBaseAddress = builder.Configuration.GetSection("RestCountriesAPI:BaseAddress").Value;

// Registra o HttpClient e configura a pol�tica de reintentativas
builder.Services.AddHttpClient("RestCountriesAPI", client =>
{
    if (!string.IsNullOrEmpty(apiBaseAddress))
    {
        client.BaseAddress = new Uri(apiBaseAddress);
        // Configure outras op��es, se necess�rio
    }
    else
    {
        // Lida com o cen�rio em que apiBaseAddress � nulo ou vazio.
        // Pode ser �til lan�ar uma exce��o, adicionar um log ou tomar outra a��o apropriada.
    }
});

builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Country}/{action=Index}");
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
