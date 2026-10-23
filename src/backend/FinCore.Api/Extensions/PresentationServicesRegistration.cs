using FinCore.Middlewares;

namespace FinCore.Extensions
{
    public static class PresentationServicesRegistration
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
