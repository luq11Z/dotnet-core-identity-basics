using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_identity_basics.Extensions
{
    public static class RazorExtensions
    {
        //In case we want to validate on a razor view based on claims
        public static bool IfClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateUserClaims(page.Context, claimName, claimValue);
        }

        //In case we want to disable for example a button through claims validation
        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateUserClaims(page.Context, claimName, claimValue) ? "" : "disabled";
        }

        //In case of html content, for example, to show a link based on claims validation
        public static IHtmlContent IfClaimShow(this IHtmlContent page, HttpContext context ,string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateUserClaims(context, claimName, claimValue) ? page : null;
        }
    }
}
