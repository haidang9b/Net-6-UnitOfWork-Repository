using BE.Extensions;
using BE.Infrastructure;
using BE.Infrastructure.Bussiness;
using BE.Infrastructure.Contracts;
using BE.Infrastructure.Data;
using BE.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages().AddNewtonsoftJson();
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddSwaggerServices();


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