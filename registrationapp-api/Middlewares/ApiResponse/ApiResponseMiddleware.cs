using System.Text;
using System.Text.Json;

namespace RegistrationApp.Middlewares
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalResponseBody = context.Response.Body;

            try
            {
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await _next(context);

                if (context.Response.StatusCode == 200 && context.Response.ContentType?.Contains("application/json") == true)
                {
                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                    context.Response.Body.Seek(0, SeekOrigin.Begin);

                    var responseData = JsonSerializer.Deserialize<object>(responseBodyText);

                    var apiResponse = new ApiResponse<object>(context.Response.StatusCode, responseData);
                    var apiResponseJson = JsonSerializer.Serialize(apiResponse);

                    await using var apiResponseBody = new MemoryStream(Encoding.UTF8.GetBytes(apiResponseJson));
                    await apiResponseBody.CopyToAsync(originalResponseBody);
                }
            }
            catch (Exception ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var errorResponse = new ApiResponse<object?>(500, null, ex.Message);
                var errorResponseJson = JsonSerializer.Serialize(errorResponse);

                await using var errorResponseBody = new MemoryStream(Encoding.UTF8.GetBytes(errorResponseJson));
                await errorResponseBody.CopyToAsync(originalResponseBody);
            }
            finally
            {
                context.Response.Body = originalResponseBody;
            }
        }
    }
}