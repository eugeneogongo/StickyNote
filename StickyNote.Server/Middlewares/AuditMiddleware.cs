using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace StickyNote.Server.Middlewares
{
    /// <summary>
    /// This is a dummy audit logs
    /// </summary>
    public class AuditMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<AuditMiddleware> auditLogger;

        public AuditMiddleware(ILogger<AuditMiddleware> logger , RequestDelegate next)
        {
            this.auditLogger = logger;
            _next = next;

        }
        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            auditLogger.LogInformation(" Method = {method}, StatusCode = {statuscode}, Path = {path} IpAddress = {UserIp}",httpContext.Request.Method,httpContext.Response.StatusCode, httpContext.Request.Path, httpContext.Request.HttpContext.Connection?.RemoteIpAddress?.ToString());

        }
    }
}
