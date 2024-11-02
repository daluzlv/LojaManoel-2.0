namespace Loja_Manoel.Middlewares;

public class LowercaseUrlMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.HasValue && context.Request.Path.Value.Any(char.IsUpper))
        {
            context.Response.Redirect(context.Request.Path.Value.ToLower() + context.Request.QueryString, true);
            return;
        }

        await next(context);
    }
}

public static class LowercaseUrlMiddlewareExtensions
{
    public static IApplicationBuilder UseLowercaseUrls(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LowercaseUrlMiddleware>();
    }
}