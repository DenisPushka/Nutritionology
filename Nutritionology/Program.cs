using DataAccess;
using DataAccess.Interface;
using DataAccess.Providers;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Nutritionology;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddIdentity<User, UserRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 8; // TODO вынести.
    options.Password.RequireNonAlphanumeric = true;  // требуются ли не алфавитно-цифровые символы
    options.Password.RequireLowercase = true;   // требуются ли символы в нижнем регистре
    options.Password.RequireUppercase = true;   // требуются ли символы в верхнем регистре
    options.Password.RequireDigit = true;   // требуются ли цифры
})
.AddRoles<UserRole>()
.AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddTransient<MRAspNet>();
builder.Services.AddTransient<MRLinq2Db>();
builder.Services.AddTransient<IMRRepository, MRRepository>();

builder.Services.AddDbContext<IdentityContext>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

//var assembly = typeof(AccountController).Assembly;
//var part = new AssemblyPart(assembly);
//builder.Services.AddControllersWithViews()
//    .ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(part));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
