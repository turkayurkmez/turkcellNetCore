namespace Middlewares.MiddlewareApp
{
    public class CreateResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public CreateResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Items["IE"] as bool? == true)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                //context.Items["Reason"] = "IE";
                // await context.Response.WriteAsync("IE desteklenmiyor");
            }

            await _next.Invoke(context);
        }
    }
}
