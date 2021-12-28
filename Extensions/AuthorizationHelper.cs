using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_identity_basics.Extensions
{
    public class NecessaryPermissions : IAuthorizationRequirement
    {
        public string Permission { get; set; }

        public NecessaryPermissions(string permission)
        {
            Permission = permission;
        }
    }

    public class NecessaryPermissionHandler : AuthorizationHandler<NecessaryPermissions>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NecessaryPermissions requirement)
        {
            if(context.User.HasClaim(c => c.Type == "Permission" && c.Value.Contains(requirement.Permission)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
