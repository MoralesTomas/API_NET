public class TimeMiddleware
{

    //esto es para referenciar el middleware que sigue
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {

        //aca colocamos la hora al final
        if (!context.Response.HasStarted)
            {
                await next.Invoke(context);
            }

        if(context.Request.Query.Any(p=> p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }

        

        // await next(context);
    }

}


    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }