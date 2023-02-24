namespace Curso_Api_Rest.Middleware
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;


        public TimeMiddleware(RequestDelegate requestDelegate) {
        
        next= requestDelegate;
        
        }


        public async Task Invoke(HttpContext context) {

            await next(context);
            if (context.Request.Query.Any(p => p.Key == "time")) {


                await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            
            }



        
        }

    }

    public static class TimeMiddlewareExtensions {

        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) { 
        
        
        
        return builder.UseMiddleware<TimeMiddleware>();
        
        }
    
    
    }
}
