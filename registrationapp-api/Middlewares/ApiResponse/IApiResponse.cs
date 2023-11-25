namespace registrationapp.Middlewares.ApiResponse
{
    /// <summary>
    /// Standardized object for any API response.
    /// </summary>
    public interface IApiResponse<T>
    {
        int StatusCode { get; set; }
        T Data { get; set; }
        string? ErrorMessage { get; set; }
    }
}