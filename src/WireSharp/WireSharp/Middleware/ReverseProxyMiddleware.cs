using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WireSharp.Middleware
{
    public class ReverseProxyMiddleware
    {
        private readonly RequestDelegate _next;

        public ReverseProxyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            await _next(context);
        }
    }
}
