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
    options.Password.RequiredLength = 8; // TODO �������.
    options.Password.RequireNonAlphanumeric = true;  // ��������� �� �� ���������-�������� �������
    options.Password.RequireLowercase = true;   // ��������� �� ������� � ������ ��������
    options.Password.RequireUppercase = true;   // ��������� �� ������� � ������� ��������
    options.Password.RequireDigit = true;   // ��������� �� �����
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
