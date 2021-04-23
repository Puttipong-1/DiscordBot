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
        private readonly SecretSetting secretSetting;
        public JwtMiddleware(RequestDelegate _next,IOptions<SecretSetting> _secretSetting)
        {
            next = _next;
            secretSetting = _secretSetting.Value;
        }
        public async Task Invoke(HttpContext context, IAdminService adminService) {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(token !=null) AttachAdminToContext(context, adminService, token);
            await next(context);
        }
        private void AttachAdminToContext(HttpContext context,IAdminService adminService,string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(secretSetting.JWTSecret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validaToken);
                JwtSecurityToken jwtToken = (JwtSecurityToken)validaToken;
                int id = int.Parse(jwtToken.Claims.First(x => x.Type == "adminId").Value);
                Console.WriteLine(id);
                var admin = adminService.GetById(id);
                Console.WriteLine("null: "+admin is null);
                context.Items["Admin"] = admin;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
