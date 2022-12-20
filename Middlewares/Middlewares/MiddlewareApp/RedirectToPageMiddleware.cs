namespace Middlewares.MiddlewareApp
{
    public class RedirectToPageMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectToPageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status400BadRequest && context.Items["IE"] as bool? == true)
            {
                context.Request.Path = "/error.html";
            }
            await _next.Invoke(context);
        }
    }
}
