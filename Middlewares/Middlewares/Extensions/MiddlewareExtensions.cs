using Middlewares.MiddlewareApp;

namespace Middlewares.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseIEChecker(this IApplicationBuilder app)
        {
            app.UseMiddleware<IECheckerMiddleware>();
            app.UseMiddleware<CreateResponseMiddleware>();
            app.UseMiddleware<RedirectToPageMiddleware>();

            return app;
        }
    }
}
