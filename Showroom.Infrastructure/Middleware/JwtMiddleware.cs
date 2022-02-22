using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Showroom.Domain;
using Showroom.Infrastructure.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Showroom.Infrastructure.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate requestDelegate, IOptions<AppSettings> appSettings)
        {
            _requestDelegate = requestDelegate;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, Context dataContext)
        {
            string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await attachAccountToContext(context, dataContext, token);
            }

            await _requestDelegate(context);
        }

        private async Task attachAccountToContext(HttpContext context, Context dataContext, string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
                int id = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                context.Items["User"] = await dataContext.Users.FindAsync(id);
            }
            catch
            {
            }
        }
    }
}
