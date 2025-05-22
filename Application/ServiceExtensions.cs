using System.Reflection;
using Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());//AutoMapper ki registration hagai yaha per

            // services.AddAutoMapper(typeof(MappingProfile).Assembly); // Aapke case me agar mapping
            // Application ya Infrastructure project me hai, to second wala approach lagana padega.


            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // register
        }
    }
}



