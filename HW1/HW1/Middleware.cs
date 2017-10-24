using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW1
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //до выполнения запроса
            var indicatorMiddleware = new Indicator();
            indicatorMiddleware.Start();
            await context.Response.WriteAsync("<br>Start indicatorMiddleware!");
            await _next.Invoke(context);
            //после выполнения запроса
            indicatorMiddleware.End();
            await context.Response.WriteAsync($"<br>IndicatorMiddleware = {indicatorMiddleware.Time()} ms");
        }
    }
}
