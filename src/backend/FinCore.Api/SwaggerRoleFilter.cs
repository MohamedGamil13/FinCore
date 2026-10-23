using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FinCore
{
    public class SwaggerRoleFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authAttributes = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Where(a => !string.IsNullOrEmpty(a.Roles));

            var roles = authAttributes.SelectMany(a => a.Roles.Split(',')).Distinct().ToList();

            if (roles.Any())
            {
                operation.Description += $"\n\n** Required Roles:** {string.Join(", ", roles)}";
                operation.Summary = $"[{string.Join("/", roles)}] " + operation.Summary;
            }
        }
    }
}
