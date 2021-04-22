using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse() { }
        public AuthenticateResponse(Admin admin,string token)
        {
            Id  = admin.AdminId;
            Name = admin.Name;
            token = token;
        }
    }
}
