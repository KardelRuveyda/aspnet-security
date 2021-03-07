using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WhiteBlackList.Web.MiddleWares
{
    public class IPSafeMiddleWare
    {
        private readonly RequestDelegate _next;

        private readonly IPList _ipList; 

        public IPSafeMiddleWare(RequestDelegate next, IOptions<IPList> ipList)
        {
            this._next = next;
            this._ipList = ipList.Value;
        }

        public async Task Invoke(HttpContext context )
        {
            var reqIpAddress = context.Connection.RemoteIpAddress;
            var isWhiteList = _ipList.WhiteList.Where(x => IPAddress.Parse(x).Equals(reqIpAddress)).Any();

            if (!isWhiteList)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            await _next(context);

        }
    }
}
