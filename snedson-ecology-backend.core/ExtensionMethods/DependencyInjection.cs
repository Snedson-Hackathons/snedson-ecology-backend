using MediatR;
using Microsoft.Extensions.DependencyInjection;
using snedson_ecology_backend.core.Actions.EventActions;
using System.Reflection;

namespace snedson_ecology_backend.core.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreInjections
            (this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<GetEventByIdAction>();
            return services;
        }
    }
}
