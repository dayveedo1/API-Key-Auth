namespace API_Key_Auth.Data
{
    public interface IApiKeyValidator
    {
        bool isValid(string apiKey);
    }
}
