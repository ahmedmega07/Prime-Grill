using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplication(this IServiceCollection services)
        {

            var ApplicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ApplicationAssembly));


            services.AddValidatorsFromAssembly(ApplicationAssembly).AddFluentValidationAutoValidation();





            services.AddAutoMapper(ApplicationAssembly);





        }
    }
}
