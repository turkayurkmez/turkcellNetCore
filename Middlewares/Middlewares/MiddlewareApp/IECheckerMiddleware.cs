namespace Middlewares.MiddlewareApp
{
    public class IECheckerMiddleware
    {
        RequestDelegate next;

        public IECheckerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["IE"] = context.Request.Headers["User-Agent"].ToString().Contains("Trident");

            await next.Invoke(context);
        }
    }
}
