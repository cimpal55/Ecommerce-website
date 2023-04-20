using MudBlazor.Services;
using Ecommerce.Utils.ServiceRegistration;
using System.Data.SqlClient;
using LinqToDB.AspNet;
using Ecommerce.Client.DbAccess;
using LinqToDB;
using LinqToDB.AspNet.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLinqToDBContext<SqlDataAccess>((provider, options) =>
{
    var connectionString = provider.GetRequiredService<IConfiguration>()
        .GetConnectionString("Default");

    connectionString = new SqlConnectionStringBuilder(connectionString)
    {
        TrustServerCertificate = true
    }.ConnectionString;

    options
        .UseSqlServer(connectionString)
        .UseDefaultLogging(provider);
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddEcommerceServices();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();

app.Run();
