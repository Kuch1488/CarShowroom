using Microsoft.AspNetCore.Http;
using Showroom.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Infrastructure.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly AppSettings _appSettings;
    }
}
