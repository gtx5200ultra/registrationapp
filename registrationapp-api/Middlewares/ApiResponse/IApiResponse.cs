namespace RegistrationApp.Middlewares
{
    public interface IApiResponse<T>
    {
        int StatusCode { get; set; }
        T Data { get; set; }
        string? ErrorMessage { get; set; }
    }
}