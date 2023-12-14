using Microsoft.AspNetCore.Mvc;

namespace API_Key_Auth.Data
{
    public class ApiKeyAttribute : ServiceFilterAttribute

    {
        public ApiKeyAttribute()
            : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
