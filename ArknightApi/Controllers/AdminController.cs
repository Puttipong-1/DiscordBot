using ArknightApi.Data.DTO;
using ArknightApi.Data.Model;
using ArknightApi.Helper;
using ArknightApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route("api/admin/")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly SecretSetting secretSetting;
        public AdminController(IAdminService _adminService,IOptions<SecretSetting> _secretSetting)
        {
            adminService = _adminService;
            secretSetting = _secretSetting.Value;
        }
        [Route("add")]
        [HttpPost]
        public async Task<ActionResult> AddAdmin(Admin admin)
        {
            try
            {
                string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (string.IsNullOrEmpty(token)) return new UnauthorizedResult();
                if (!token.Equals(secretSetting.SecretKey)) return new UnauthorizedResult();
                string res = await adminService.AddAdmin(admin);
                return Ok(res);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("auth")]
        [HttpPost]
        public async Task<ActionResult> Authenticate(AuthenticateRequest authenticate)
        {
            try {
                AuthenticateResponse response = await adminService.Authenticate(authenticate);
                return Ok(response);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
         }
    }
}
