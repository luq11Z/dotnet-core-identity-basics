using dotnet_core_identity_basics.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_core_identity_basics.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete"));

                options.AddPolicy("CanRead", policy => policy.Requirements.Add(new NecessaryPermissions("CanRead")));
                options.AddPolicy("CanWrite", policy => policy.Requirements.Add(new NecessaryPermissions("CanWrite")));
            });

            return services;
        }
    }
}
