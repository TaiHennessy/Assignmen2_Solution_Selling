using Assignmen2.Data;
using Assignmen2;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assignmen2.Models;
using Assignmen2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                      ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register ApplicationDbContext with Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register Identity with user and role management
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();  // Enables token-based actions like password resets

// Register ProductContext for product-related operations
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(connectionString));

// Add the ProductService for dependency injection
builder.Services.AddScoped<ProductService>();

// Add the CartService and HttpContextAccessor for cart-related operations
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICartServices, CartService>();

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add controllers with views
builder.Services.AddControllersWithViews();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Use DbInit.Initialize to seed the Product database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Apply migrations first
    try
    {
        var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
        await applicationDbContext.Database.MigrateAsync(); // Apply pending migrations
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred applying migrations to the Identity DB.");
    }

    // Seed Product database
    try
    {
        var productContext = services.GetRequiredService<ProductContext>();
        DbInit.Initialize(productContext);  // Initialize product data
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the Product DB.");
    }

    // Seed Identity DB with roles and users
    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await DbSeeder.Seed(userManager, roleManager); // Seed roles and users
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the Identity DB.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add middleware to redirect from /Home to the root ("/")
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/Home")
    {
        context.Response.Redirect("/", permanent: true);  // Redirects to "/"
        return;  // Stop further processing
    }
    await next();  // Proceed to the next middleware if not "/Home"
});

// Enable session middleware
app.UseSession();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Configure default route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
    