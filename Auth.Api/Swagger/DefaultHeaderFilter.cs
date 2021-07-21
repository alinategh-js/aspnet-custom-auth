using Auth.Api.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth.Api.Swagger
{
    public class DefaultHeaderFilter : IOperationFilter
    {
        private IConfiguration _configuration { get; }

        public DefaultHeaderFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var requiredPolicies = context.MethodInfo
                .GetCustomAttributes(true)
                .Concat(context.MethodInfo.DeclaringType.GetCustomAttributes(true))
                .OfType<AuthorizeFilter>();

            if (requiredPolicies.Any())
            {
                var oAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [ oAuthScheme ] = new List<string> { "Authorization" }
                    }
                };
            }
        }
    }
}
