namespace FinCore.Extensions
{
    public static class WebApiExtension
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerDocs();
            services.AddControllers();
            //  services.RegisterMapsterConfiguration();
            return services;
        }
    }
}
