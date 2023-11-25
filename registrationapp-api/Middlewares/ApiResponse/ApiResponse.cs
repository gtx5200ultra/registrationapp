using System.Text.Json.Serialization;

namespace RegistrationApp.Middlewares
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("errorMessage")]
        public string? ErrorMessage { get; set; }

        public ApiResponse(T data)
        {
            StatusCode = StatusCodes.Status200OK;
            Data = data;
            ErrorMessage = string.Empty;
        }

        public ApiResponse(int statusCode, T data, string? errorMessage = null)
        {
            StatusCode = statusCode;
            Data = data;
            ErrorMessage = errorMessage;
        }
    }
}
