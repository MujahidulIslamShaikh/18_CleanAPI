
using Application.Interfaces;

using Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;

namespace Persistance
{
    public static class ServiceExtensions
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            // Register Services.

            // Register DbContext
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                ));

            // Register IApplicationDbContext
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        

        }
    }
}
