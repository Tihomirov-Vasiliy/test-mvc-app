using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Initialize and seed database
using (var scope = app.Services.CreateScope())
{
    //enables adding datetime values in unspecified kind to database (without this, throws error)
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await initialiser.InitializeAsync();
    await initialiser.TrySeedAsync();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
