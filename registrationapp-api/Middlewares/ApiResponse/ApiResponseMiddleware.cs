using System.Text;
using System.Text.Json;

namespace registrationapp.Middlewares.ApiResponse
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBody = context.Response.Body;

            try
            {
                using var memStream = new MemoryStream();

                context.Response.Body = memStream;

                await _next(context);

                memStream.Position = 0;

                switch (context.Response.StatusCode)
                {
                    case StatusCodes.Status200OK:
                        {
                            context.Response.ContentType = "application/json";
                            var responseData = JsonSerializer.Deserialize<object>(await new StreamReader(memStream).ReadToEndAsync());
                            var apiResponse = new ApiResponse<object>(context.Response.StatusCode, responseData ?? new { });
                            await using var responseBody = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(apiResponse)));
                            await responseBody.CopyToAsync(originalBody);
                            break;
                        }
                    case StatusCodes.Status400BadRequest:
                        {
                            context.Response.ContentType = "application/json";
                            var errorText = await new StreamReader(memStream).ReadToEndAsync();
                            var apiResponse = new ApiResponse<object?>(context.Response.StatusCode, null, errorText);
                            await using var responseBody = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(apiResponse)));
                            await responseBody.CopyToAsync(originalBody);
                            break;
                        }
                    default:
                        {
                            memStream.Position = 0;
                            await memStream.CopyToAsync(originalBody);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                /* any logger implementation if needed */

                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var errorResponse = JsonSerializer.Serialize(new ApiResponse<string?>(500, null, ex.Message));
                await using var errorResponseBody = new MemoryStream(Encoding.UTF8.GetBytes(errorResponse));
                await errorResponseBody.CopyToAsync(originalBody);
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
    }
}