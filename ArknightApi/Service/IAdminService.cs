using ArknightApi.Data.DTO;
using ArknightApi.Data.Model;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public interface IAdminService
    {
        Admin GetById(int id);
        Task<string> AddAdmin(Admin admin);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticate);
        string GenerateJwtToken(Admin admin);
    }
}
