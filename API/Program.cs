using Application;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Persistance;
using Persistance.Context;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register identity   
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
   
// ✅ Add CORS policy here
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Dependency Injection 
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPersistance(builder.Configuration);


var app = builder.Build();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Use CORS middleware here
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
