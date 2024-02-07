using System.Diagnostics;

namespace StickyNote.Server.Middlewares
{
    /// <summary>
    /// This a dummy class to emit metrics to monitor QOS per path
    /// Ir prints the a log message but Grafana dashboard could be ideal solution
    /// </summary>
    public class QOSMiddleware
    {
        private ILogger<QOSMiddleware> logger;
        private readonly RequestDelegate _next;
        public QOSMiddleware(ILogger<QOSMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            _next = next;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            _next.Invoke(httpContext);
            stopwatch.Stop();
            logger.LogInformation("TimeTaken = {timetaken}, Method = {method}, StatusCode = {statuscode}, Path = {path}", stopwatch.ElapsedMilliseconds,httpContext.Request.Method, httpContext.Response.StatusCode, httpContext.Request.Path);
        }
    }
}
