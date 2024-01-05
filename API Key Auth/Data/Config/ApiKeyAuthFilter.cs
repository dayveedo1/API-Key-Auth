using ApiKeyAuth.Data.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_Key_Auth.Data.Config
{
    public class ApiKeyAuthFilter : Attribute, IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
               
                context.Result = new UnauthorizedObjectResult("API key not found.");
                return;
            }


            /*
               - use this approach to inject configuration when using filter as an attribute
               - don't forget to disable the Iconfiguration injection in the constructor
            */

            //var _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();   

            var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);
            if (!apiKey.Equals(extractedApiKey) || String.IsNullOrEmpty(apiKey))
            {
                context.Result = new UnauthorizedObjectResult("Invalid API key");
                return;
            }
        }

    }
}
