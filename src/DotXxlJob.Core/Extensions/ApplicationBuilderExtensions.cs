using DotXxlJob.Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace DotXxlJob.Core.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseXxlJobExecutor(this IApplicationBuilder @this)
        {
            return @this.UseMiddleware<XxlJobExecutorMiddleware>();
        }
    }
}