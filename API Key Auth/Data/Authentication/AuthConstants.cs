namespace ApiKeyAuth.Data.Authentication
{
    public static class AuthConstants
    {
        public const string ApiKeySectionName = "Authentication:ApiKey";    //path to settings in AppSetting.json
        public const string ApiKeyHeaderName = "X-Api-Key";                 //header name
    }
}
