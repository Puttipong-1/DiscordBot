using ArknightApi.Data;
using ArknightApi.Data.DTO;
using ArknightApi.Data.Model;
using ArknightApi.Helper;
using Isopoh.Cryptography.Argon2;
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
        private readonly SecretSetting secretSetting;
        public AdminService(ApplicationDbContext _applicationDb,IOptions<SecretSetting> _secretSetting)
        {
            applicationDb = _applicationDb;
            secretSetting = _secretSetting.Value;
        }
        public async Task<string> AddAdmin(Admin admin)
        {
            try
            { 
                Admin a = await applicationDb.Admins
                    .Where(a => a.Email.Equals(admin.Email))
                    .FirstOrDefaultAsync();
                if (a!=null)
                {
                    return "Email already exist";
                }
                admin.Password = Argon2.Hash(admin.Password);
                await applicationDb.AddAsync(admin);
                await applicationDb.SaveChangesAsync();
                return "Add admin success";
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticate)
        {
            try
            {
                Admin admin = await applicationDb.Admins.FirstOrDefaultAsync(a => a.Email.Equals(authenticate.Email));
                if (admin is null) return null;
                if (!Argon2.Verify(admin.Password, authenticate.Password)) return null;
                string token = GenerateJwtToken(admin);
                return new AuthenticateResponse(admin,token);
                

            }catch(Exception e)
            {
                throw e;
            }
        }

        public string GenerateJwtToken(Admin admin)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secretSetting.JWTSecret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("adminId", admin.AdminId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Admin GetById(int id)
        {
            return applicationDb.Admins.FirstOrDefault(x => x.AdminId == id);
        }

    }
}
