using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotXxlJob.Core.Middlewares
{
    public class XxlJobExecutorMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly XxlRestfulServiceHandler _rpcService;
        
        private readonly List<string> _xxlJobUris = new List<string>() { "/beat", "/idlebeat", "/run", "/kill", "/log" };
        

        public XxlJobExecutorMiddleware(IServiceProvider provider, RequestDelegate next)
        {
            this._next = next;
            this._rpcService = provider.GetRequiredService<XxlRestfulServiceHandler>();
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path;
            if (_xxlJobUris.Contains(path))
            {
                await _rpcService.HandlerAsync(context.Request, context.Response);
                return;
            }

            await _next.Invoke(context);
        }
    }
}
