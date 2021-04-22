using ArknightApi.Data;
using ArknightApi.Data.DTO;
using ArknightApi.Data.Model;
using ArknightApi.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly AppSetting appSetting;
        public AdminService(ApplicationDbContext _applicationDb, IOptions<AppSetting> _appSetting)
        {
            applicationDb = _applicationDb;
            appSetting = _appSetting.Value;
        }
        public async Task<string> AddAdmin(Admin admin)
        {
            try
            {
                Admin a = await applicationDb.Admins
                    .Where(a => a.Email.Equals(admin.Email))
                    .FirstOrDefaultAsync();
                if (a is null)
                {
                    return "Email already exist";
                }
                await applicationDb.AddAsync(admin);
                await applicationDb.SaveChangesAsync();
                return "Add admin success";
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticate)
        {
            throw new NotImplementedException();
        }

        public string GenerateJwtToken(Admin admin)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSetting.JWTSecret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("adminId", admin.AdminId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Admin> GetById(int id)
        {
            return await applicationDb.Admins.FirstOrDefaultAsync(x => x.AdminId == id);
        }

    }
}
