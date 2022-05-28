using BE.Infrastructure;
using BE.Infrastructure.Bussiness;
using BE.Infrastructure.Contracts;
using BE.Infrastructure.Data;
using BE.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");

// Add services to the container.
builder.Services.AddRazorPages().AddNewtonsoftJson();
RegisterServices(builder.Services);
builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Clothing Store API",
        Description = "Backend API for Clothing Store project",

    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapRazorPages();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
}); 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});
app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddDbContext<EFContext>(options =>
    options.UseSqlServer(connectionString));
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddScoped(typeof(IDatabaseFactory<>), typeof(DatabaseFactory<>));
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
}