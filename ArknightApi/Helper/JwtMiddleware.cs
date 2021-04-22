using ArknightApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightApi.Helper
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate    next;
        private readonly AppSetting appSetting;
        public JwtMiddleware(RequestDelegate _next,IOptions<AppSetting> _appsetting)
        {
            next = _next;
            appSetting = _appsetting.Value;
        }
        public async Task Invoke(HttpContext context, IAdminService adminService) {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(token !=null) await AttachAdminToContext(context, adminService, token);
            await next(context);
        }
        private async Task AttachAdminToContext(HttpContext context,IAdminService adminService,string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(appSetting.JWTSecret);
                tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validaToken);
                JwtSecurityToken jwtToken = (JwtSecurityToken)validaToken;
                int id = int.Parse(jwtToken.Claims.First(x => x.Type == "adminId").Value);
                context.Items["Admin"] = await adminService.GetById(id);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
